using System.Runtime.Serialization;

namespace Service.AssetsDictionary.Grpc.Models
{
    [DataContract]
    public class HelloGrpcRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
}
