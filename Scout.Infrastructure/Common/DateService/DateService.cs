using Scout.Application.Common.Services;

namespace Scout.Infrastructure.Common.DateService;
public class DateService : IDateService
{
    public DateTime CurrentDate() => DateTime.UtcNow;
    public DateTimeOffset CurrentOffsetDate() => DateTimeOffset.UtcNow;
}