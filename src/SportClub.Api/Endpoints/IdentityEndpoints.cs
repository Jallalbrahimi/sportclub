using MediatR;
using Microsoft.AspNetCore.Identity;
using SportClub.Application.Features.Identity.Commands;
using SportClub.Application.Features.User.Commands;

namespace SportClub.Api.Endpoints
{
    record RegisterRequest(string email, string password);
    record LoginRequest(string email, string password);

    public static class IdentityEndpoints
    {

        public static void MapIdentityEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/login", async (LoginCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return result ? Results.Ok() : Results.Unauthorized(); 
            });

            app.MapPost("/api/register", async (RegisterCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            });

        }
    }
}
