using Autofac;
using Microsoft.Extensions.Logging;
using Service.AssetsDictionary.Grpc;
using Service.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.AssetsDictionary.Client
{
    public static class AutofacHelper
    {
        public static void RegisterAssetsDictionaryClient(this ContainerBuilder builder, string grpcServiceUrl, ILogger logger)
        {
            var factory = new AssetsDictionaryClientFactory(grpcServiceUrl, logger);

            builder.RegisterInstance(factory.GetAssetsDictionaryService()).As<IGrpcServiceProxy<IAssetsDictionaryService>>().SingleInstance();
        }
    }
}
