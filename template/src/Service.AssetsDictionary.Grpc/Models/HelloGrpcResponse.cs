using System.Runtime.Serialization;

namespace Service.AssetsDictionary.Grpc.Models
{
    [DataContract]
    public class HelloGrpcResponse
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}
