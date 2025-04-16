using MediatR;
using SportClub.Domain.Entities;
using SportClub.Application.Features.User.Interfaces;

namespace SportClub.Application.Features.User.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserService _userRepository;

        public CreateUserHandler(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid()
            };

            return await _userRepository.CreateUserAsync(user, cancellationToken);
        }
    }
}
