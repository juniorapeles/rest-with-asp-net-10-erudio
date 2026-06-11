using RestWithASPNET10Erudio.Data.DTO.V1;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class InstanceInformationService : IInstanceInformationService
    {
        public InstanceInformationDTO GetInstanceInformation()
        {
            var isRunningInContainer = string.Equals(
                Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"),
                "true",
                StringComparison.OrdinalIgnoreCase);

            var instanceId = isRunningInContainer
                ? Environment.GetEnvironmentVariable("HOSTNAME") ?? Environment.MachineName
                : "local";

            return new InstanceInformationDTO
            {
                Environment = isRunningInContainer ? "container" : "local",
                InstanceId = instanceId,
                Message = isRunningInContainer
                    ? $"Hello Docker from container {instanceId}"
                    : "Hello Docker from local"
            };
        }
    }
}
