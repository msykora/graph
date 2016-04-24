using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WebServices {
    [ServiceContract]
    public interface IDataService {
        [OperationContract]
        IEnumerable<Node> Get();

        [OperationContract]
        void Put(IEnumerable<Node> nodes);
    }

    [DataContract(Name = "node", Namespace = "")]
    public class Node {
        [DataMember(Name = "id", Order = 0)]
        public string Id;

        [DataMember(Name = "label", Order = 1)]
        public string Label;

        [DataMember(Name = "adjacentNodes", Order = 2)]
        public AdjacentNodes AdjacentNodes;
    }

    [CollectionDataContract(Name = "adjacentNodes", ItemName = "id", Namespace = "")]
    public class AdjacentNodes : List<string> {}
}