namespace PeanutLabs.Configuration
{
    public interface IPeanutLabsConfiguration
    {
        string ApplicationId { get; }
        string ApplicationKey { get; }
        string BaseUrl { get; }
    }
}