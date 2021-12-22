using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.AssetsDictionary.Grpc;
using Service.AssetsDictionary.Grpc.Models;

namespace Service.AssetsDictionary.Services
{
    public class AssetsDictionaryService : IAssetsDictionaryService
    {
        private readonly ILogger<AssetsDictionaryService> _logger;

        public AssetsDictionaryService(ILogger<AssetsDictionaryService> logger)
        {
            _logger = logger;
        }

        public Task<HelloGrpcResponse> SayHelloAsync(HelloGrpcRequest grpcRequest)
        {
            _logger.LogInformation("Hello from {name}", grpcRequest.Name);

            return Task.FromResult(new HelloGrpcResponse
            {
                Message = "Hello " + grpcRequest.Name
            });
        }
    }
}
