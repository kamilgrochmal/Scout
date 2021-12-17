using MediatR;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Application.Commands;

public record CreateScoutObject(string Name, string PostalCode, string City, string Street, string PlotNumber,
   ObjectStatus ObjectStatus, ObjectType ObjectType ) : IRequest;