using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportClub.Application.Features.UserProfile.Commands;
using SportClub.Application.Features.UserProfile.Queries;

namespace SportClub.Api.Endpoints
{
    public static class UserEndpoints
    {

        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            // POST: /api/users
            app.MapPost("/api/users", async (CreateUserProfileCommand command, IMediator mediator) =>
            {
                var userId = await mediator.Send(command);
                return Results.Created($"/api/users/{userId}", userId);
            });

            // GET: /api/users
            app.MapGet("/api/users", async ([FromServices] IMediator mediator) =>
            {
                var users = await mediator.Send(new GetUserProfilesQuery());
                return Results.Ok(users);
            });
        }

    }
}
