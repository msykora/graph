using System.Collections.Generic;
using System.ServiceModel;

namespace WebServices {
    [ServiceContract]
    public interface IPathService {
        [OperationContract]
        List<string> FindShortestPath(string startNodeId, string destinationNodeId);
    }
}