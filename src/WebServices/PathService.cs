using System.Collections.Generic;
using System.Linq;

namespace WebServices {
    public class PathService : IPathService {
        private readonly NodesModel data = new NodesModel();

        public List<string> FindShortestPath(string startNodeId, string destinationNodeId) {
            var pathPredecessor = new Dictionary<string, string>();
            GetValue(startNodeId, destinationNodeId, pathPredecessor);
            var path = new List<string>();
            var nodeId = destinationNodeId;
            do {
                path.Add(nodeId);
                nodeId = pathPredecessor[nodeId];
            } while (nodeId != startNodeId);
            return path;
        }

        private void GetValue(string startNodeId, string destinationNodeId, Dictionary<string, string> pathPredecessor) {
            var nodes = new Queue<Node>();
            nodes.Enqueue(data.Get(startNodeId));
            while (nodes.Count > 0) {
                var node = nodes.Dequeue();
                foreach (var neighbor in node.AdjacentNodes.Where(neighbor => !pathPredecessor.ContainsKey(neighbor))) {
                    pathPredecessor[neighbor] = node.Id;
                    if (neighbor == destinationNodeId)
                        break;
                    nodes.Enqueue(data.Get(neighbor));
                }
            }
        }
    }
}