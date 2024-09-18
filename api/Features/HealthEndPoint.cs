using FastEndpoints;

namespace api.Features;

public class HealthEndPoint: Endpoint<HealthRequest, HealthResponse>
{
    public override void Configure()
    {
        Get("/health");
        AllowAnonymous();
    }

    public override async Task<HealthResponse> ExecuteAsync (HealthRequest req, CancellationToken ct)
    {
        return new HealthResponse { Status= req.Name.ToUpper()};
    }
}

public record HealthRequest
{
    public string? Name { get; set; } = "";
}

public record HealthResponse
{
    public string? Status { get; set; } = "";
}