using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportClub.Application.Features.UserProfile.Commands;
using SportClub.Application.Features.UserProfile.Queries;

namespace SportClub.Api.Endpoints
{
    public static class ProfileEndpoints
    {

        public static void MapProfileEndpoints(this IEndpointRouteBuilder app)
        {
            // POST: /api/profile
            app.MapPost("/api/profile", async (EditProfileCommand command, IMediator mediator) =>
            {
                var profileId = await mediator.Send(command);
                return Results.Ok(profileId);
            });

            // GET: /api/profile/{profileId}
            app.MapGet("/api/profile", async ([FromServices] IMediator mediator, int profileId) =>
            {
                var users = await mediator.Send(new GetProfileQuery());
                return Results.Ok(users);
            });
        }

    }
}
