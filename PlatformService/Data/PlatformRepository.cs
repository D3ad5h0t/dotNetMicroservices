using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool SaveChanges() => _context.SaveChanges() >= 0;

    public IEnumerable<Platform> GetAllPlatforms() => _context.Platforms.ToList();

    public Platform GetPlatformById(int id) => _context.Platforms.FirstOrDefault(p => p.Id == id);

    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }

        _context.Platforms.Add(platform);
    }
}