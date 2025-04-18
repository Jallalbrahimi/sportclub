using MediatR;
using SportClub.Application.Features.Authentication.Commands;

namespace SportClub.Api.Endpoints
{
    record RegisterRequest(string email, string password);
    record LoginRequest(string email, string password);

    public static class AuthenticationEndpoints
    {

        public static void MapIdentityEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/login", async (LoginCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return (result != null) ? Results.Ok(result) : Results.Unauthorized();
            });

            app.MapPost("/api/register", async (RegisterCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            });

        }
    }
}
