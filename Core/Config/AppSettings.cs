using Sampas_Mobil_Etkinlik.Common.Enums.Infrastructure;

namespace Sampas_Mobil_Etkinlik.Core.Config;

public class AppSettings
{
    public ApplicationEnvironment Environment { get; set; }
    // public ApplicationDatabaseProvider DatabaseProvider { get; set; }
    // public CaptchaProvider CaptchaProvider { get; set; }
    // public string EmailTemplateFolder { get; set; }
    public string PrivateRSAPemFile { get; set; }
    public string PrivateRSAPemFilePass { get; set; }
}

public static class ApplicationEnvironmentEnumExtensions
{
    public static bool IsDevelopment(this ApplicationEnvironment environment)
    {
        return environment == ApplicationEnvironment.Development;
    }

    public static bool IsStaging(this ApplicationEnvironment environment)
    {
        return environment == ApplicationEnvironment.Staging;
    }
    public static bool IsProduction(this ApplicationEnvironment environment)
    {
        return environment == ApplicationEnvironment.Production;
    }
}

