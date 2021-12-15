﻿using MediatR;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Application.Commands;

public record CreateScoutObject(string Name, string PostalCode, string City, string Street, string PlotNumber,
    double? Latitude, double? Longitude, double? TerrainHeight,
    double? ObjectHeight, double? AntennaSetHeight, PowerSupplyType? PowerSupplyType, CoolingType? CoolingType,
    string Others, ObjectStatus ObjectStatus, ObjectType ObjectType, string IpAddress, string UrlToObject) : IRequest;