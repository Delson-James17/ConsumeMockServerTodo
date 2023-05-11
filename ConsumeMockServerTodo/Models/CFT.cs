namespace ConsumeMockServerTodo.Models
{
    public class CFT
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
        public CFT()
        {
            
        }
        public CFT(int userId, int id, string title, bool completed)
        {
            this.userId = userId;
            this.Id = id;
            this.title = title;
            this.completed = completed;
        }   
    }
}
