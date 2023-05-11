using Microsoft.AspNetCore.Mvc;

namespace ConsumeMockServerTodo.ViewModel
{
    public class CFTViewModel : Controller
    {
        public int userId { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        public CFTViewModel()
        {
            
        }
        public CFTViewModel(int userId, string title, bool completed)
        {
            this.userId = userId;
            this.title = title;
            this.completed = completed;
        }
    }
}
