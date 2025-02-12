using MediatR;

namespace ContactManagment.Application.Contact.Commands.DeleteContactCommand
{
    public record DeleteContactCommand(Guid Id) : IRequest;
}
