using MediatR;
using Scout.Domain.Repositories;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ValueObjects;

namespace Scout.Application.Commands.Handlers;

public class CreateScoutObjectHandler : IRequestHandler<CreateScoutObject>
{
    private readonly IScoutObjectRepository _scoutObjectRepository;

    public CreateScoutObjectHandler(IScoutObjectRepository scoutObjectRepository)
    {
        _scoutObjectRepository = scoutObjectRepository;
    }
    
    public async Task<Unit> Handle(CreateScoutObject request, CancellationToken cancellationToken)
    {

        var (name, postalCode, city, street, plotNumber,
            latitude, longitude, terrainHeight,
            objectHeight, antennaSetHeight, powerSupplyType, coolingType,
            others, objectStatus, objectType, ipAddress, urlToObject) = request;

        var objectName = ScoutObjectName.Create(name);
        var address = Address.Create(street, postalCode, city, plotNumber);
        var localization = WGSGeoLocalization.Create(latitude, longitude, terrainHeight);
        var specification = ObjectSpecification.Create(antennaSetHeight, coolingType, powerSupplyType, objectHeight, others);
        var ip = IpAddress.Create(ipAddress);

        var scoutObject = ScoutObject.Create(objectName, address, localization, specification, objectStatus, objectType,
            ip, urlToObject);

        await _scoutObjectRepository.AddAsync(scoutObject);
        
        return Unit.Value;

    }
}