using MediatR;

namespace Scout.Application.Commands;

public record AddScoutObjectOwner(long ScoutObjectId, string FirstName, string LastName, string PostalCode, string City,
    string Street, string CompanyName, string Email, string PhoneNumber, string UrlSite) : IRequest;