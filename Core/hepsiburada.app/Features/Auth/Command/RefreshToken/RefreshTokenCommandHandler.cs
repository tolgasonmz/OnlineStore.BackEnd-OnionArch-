using hepsiburada.app.Bases;
using hepsiburada.app.Features.Auth.Rules;
using hepsiburada.app.Interfaces.AutoMapper;
using hepsiburada.app.Interfaces.Token;
using hepsiburada.app.Interfaces.UnitOfWorks;
using hepsiburada.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.app.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler,IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly ITokenService tokenService;

        public RefreshTokenCommandHandler(AuthRules authRules, ITokenService tokenService, UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

            string email = principal.FindFirstValue(ClaimTypes.Email);

            var user = await userManager.FindByEmailAsync(email);
            var roles = await userManager.GetRolesAsync(user);

            await authRules.RefreshTokenShouldNotBeInvalid(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new RefreshTokenCommandResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };

        }
    }
}
