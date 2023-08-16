using FluentValidation.Validators;
using FluentValidation;

namespace Notes.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(room => room.UserId).NotEqual(Guid.Empty);
        }
    }
}
