using ConsumeMockServerTodo.Models;
using ConsumeMockServerTodo.ViewModel;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeMockServerTodo.Repository.RestApi
{
    public class CFTRestRepository : ICFTRepository
    {
        string baseURL = "https://jsonplaceholder.typicode.com";
        HttpClient httpClient = new HttpClient();
        public CFTRestRepository()
        {
            
        }

        public CFT AddTask(CFT newCTF)
        {
            CFTViewModel cFTViewModel = new CFTViewModel();
            cFTViewModel.userId = newCTF.userId;
            cFTViewModel.title = newCTF.title;
            cFTViewModel.completed = newCTF.completed;
            string data = JsonConvert.SerializeObject(cFTViewModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(baseURL + "/todos", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                CFT todo = JsonConvert.DeserializeObject<CFT>(responsecontent);
                return todo;
            }
            return null;
        }

        public CFT DeleteTask(int cftid)
        {
            var response = httpClient.DeleteAsync(baseURL + "/todos/" + cftid).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                CFT todo = JsonConvert.DeserializeObject<CFT>(data);
                return todo;
            }
            return null;
        }

        public List<CFT> GetAllTasks()
        {
            // fetch todos from rest service -> http request message
            var response = httpClient.GetAsync(baseURL + "/todos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                List<CFT> todos = JsonConvert.DeserializeObject<List<CFT>>(data);
                return todos;
            }
            return null;
        }

        public CFT GetTaskById(int id)
        {
            var response = httpClient.GetAsync(baseURL + "/todos/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;// json standard
                CFT todo = JsonConvert.DeserializeObject<CFT>(data);
                return todo;
            }
            return null;
        }

        public CFT UpdateTask(int cftid, CFT newCTF)
        {
            string data = JsonConvert.SerializeObject(newCTF);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/todos/" + cftid, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                CFT todo = JsonConvert.DeserializeObject<CFT>(responsecontent);
                return todo;
            }
            return null;
        }
    }
}
