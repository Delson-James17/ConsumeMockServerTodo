using ConsumeMockServerTodo.Models;

namespace ConsumeMockServerTodo.Repository
{
    public interface ICFTRepository
    {
        List<CFT> GetAllTasks();

        CFT GetTaskById(int id);

        CFT AddTask(CFT newCTF);

        CFT UpdateTask(int cftid ,CFT newCTF);

        CFT DeleteTask(int cftid);
        
    }
}
