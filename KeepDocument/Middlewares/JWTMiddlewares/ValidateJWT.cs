using KeepDocument.Helpers.JWTHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KeepDocument.Middlewares.JWTMiddlewares
{
    public static class ValidateJWT
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,IConfiguration configulartion)
        {
            //Bind Strongly typed JWT settings

            var jwtSettings = configulartion.GetSection("JwtSettings").Get<JWTOption>();
            services.Configure<JWTOption>(configulartion.GetSection("JwtSettings"));


            var key=Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                  
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                   
                };
            });
            return services;



        }

    }
}
