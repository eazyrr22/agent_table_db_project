using CSharpAndSQL.dal;
using CSharpAndSQL.models;
namespace CSharpAndSQL
{
     
    public class Program
    {
        static void Main(string[] args)

        {
            Agent a = new Agent(1, "EagleEye", "John Doe", "New York", "Active", 5);
            AgentDAL agentDAL = new AgentDAL("server=localhost;uid=root;password=;database=eagleeyedb");
            agentDAL.AddAgent(a);
            List <Dictionary<string,object>> result = DBConnection.Execute("SELECT * FROM agents;");
         
         DBConnection.PrintResult(result);
        }
    }
}
