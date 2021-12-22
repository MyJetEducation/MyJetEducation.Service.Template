using System.ServiceModel;
using System.Threading.Tasks;
using Service.AssetsDictionary.Grpc.Models;

namespace Service.AssetsDictionary.Grpc
{
    [ServiceContract]
    public interface IAssetsDictionaryService
    {
        [OperationContract]
        Task<HelloGrpcResponse> SayHelloAsync(HelloGrpcRequest grpcRequest);
    }
}
