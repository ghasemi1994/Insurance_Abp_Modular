

namespace Application.Utility.Helpers;

public static class ServerInformation
{
    public static string GetWwwRootPath()
    => Path.Combine(AppContext.BaseDirectory.Split(new[] { "bin" }, StringSplitOptions.RemoveEmptyEntries).First(), "wwwRoot");
}
