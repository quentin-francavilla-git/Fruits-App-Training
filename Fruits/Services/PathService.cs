using Fruits.Options;

namespace Fruits.Services;

public class PathService
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;
    public PathService()
    {

    }

    public PathService(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }

    public string GetUploadsPath(string? fileName = null, bool withWebRootPath = true)
    {
        PathOptions pathOptions = new();

        _configuration.GetSection(PathOptions.Path).Bind(pathOptions);

        string uploadsPath = pathOptions.FruitsImages;

        if (fileName != null)
            uploadsPath = Path.Combine(uploadsPath, fileName);

        return withWebRootPath ? Path.Combine(_env.WebRootPath, uploadsPath) : uploadsPath;
    }
}
