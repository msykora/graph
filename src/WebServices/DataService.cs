using System.Collections.Generic;

namespace WebServices {
    public class DataService : IDataService {
        private readonly NodesModel data = new NodesModel();

        public Node Get(string id) {
            return data.Get(id);
        }

        public IEnumerable<Node> Get() {
            return data.GetAll();
        }

        public void Put(IEnumerable<Node> nodes) {
            data.DeleteAll();
            data.InsertMany(nodes);
        }
    }
}