using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Service.AssetsDictionary.Grpc;
using Service.Grpc;

namespace Service.AssetsDictionary.Client
{
    [UsedImplicitly]
    public class AssetsDictionaryClientFactory : GrpcClientFactory
    {
        public AssetsDictionaryClientFactory(string grpcServiceUrl, ILogger logger) : base(grpcServiceUrl, logger)
        {
        }

        public IGrpcServiceProxy<IAssetsDictionaryService> GetAssetsDictionaryService() => CreateGrpcService<IAssetsDictionaryService>();
    }
}
