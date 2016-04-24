using System.Collections.Generic;
using MongoDB.Driver;

namespace WebServices {
    internal class NodesModel {
        private readonly MongoClient mongo;
        private readonly IMongoDatabase graph;
        private readonly IMongoCollection<Node> nodes;

        public NodesModel() {
            mongo = new MongoClient();
            graph = mongo.GetDatabase("graph");
            nodes = graph.GetCollection<Node>("nodes");
        }

        public void DeleteAll() {
            nodes.DeleteMany(node => true);
        }

        public void InsertMany(IEnumerable<Node> newNodes) {
            nodes.InsertMany(newNodes);
        }

        public Node Get(string id) {
            var found = nodes.Find(node => node.Id == id).Limit(1).ToList();
            return found.Count == 1 ? found[0] : null;
        }

        public IEnumerable<Node> GetAll() {
            return nodes.FindAsync(node => true).Result.ToEnumerable();
        }
    }
}