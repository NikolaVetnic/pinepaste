using MediatR;
using PinePaste.Domain.Entities;

namespace PinePaste.Application.Pastes.Queries.ListPastes;

public class ListPastesQuery : IRequest<IEnumerable<Paste>> { }