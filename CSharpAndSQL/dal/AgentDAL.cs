using CSharpAndSQL.models;



namespace CSharpAndSQL.dal
{
    class AgentDAL
    {
        // Constructor
        public AgentDAL(string? connection = null)
        {
            DBConnection.Connect(connection);
            Console.WriteLine("connection set successfully");
        }

        // Methods
        public void AddAgent(Agent agent)
        {
            /* Implementation for adding an agent to the database */
            
            string sql = $"INSERT INTO agents (CodeName, RealName, Location, Status, MissionsCompleted) VALUES ('{agent.CodeName}', '{agent.RealName}', '{agent.Location}', '{agent.Status}', {agent.MissionsCompleted})";
            
            DBConnection.Execute(sql);                                           ///////////   how tם deal with the response?
        }
       
        public static List<Agent> GetAllAgent()
        {
            string sql = "SELECT * FROM agents";

            List<Dictionary<string, object?>> agents = DBConnection.Execute(sql);        // get query
            
            List <Agent> agentList = new List<Agent>();
            
            foreach (var agent in agents)                                                    // iterate through the list of agents
            {
                int id = Convert.ToInt32(agent["Id"]);
                string codeName = agent["CodeName"].ToString();
                string realName = agent["RealName"].ToString();
                string location = agent["Location"].ToString();
                string status = agent["Status"].ToString();
                int missionsCompleted = Convert.ToInt32(agent["MissionsCompleted"]);
                Agent newAgent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                
                agentList.Add(newAgent);                                                // add the new agent to the list
            }
            return agentList;                                                // return the list of agents
        }
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            /* Implementation for updating an agent's location in the database */
            string sql = $"UPDATE agents SET Location = '{newLocation}' WHERE Id = {agentId}";
            DBConnection.Execute(sql);               ///////////   how tם deal with the response?
        }
        
        public void UpdateAgentStatus(int agentId, string newStatus)
        {
            /* Implementation for updating an agent's status in the database */
            string sql = $"UPDATE agents SET Status = '{newStatus}' WHERE Id = {agentId}";
            DBConnection.Execute(sql);               ///////////   how tם deal with the response?
        }

        public void UpdateAgentMissionsCompleted(int agentId, int newMissionsCompleted)
        {
            /* Implementation for updating an agent's missions completed in the database */
            string sql = $"UPDATE agents SET MissionsCompleted = {newMissionsCompleted} WHERE Id = {agentId}";
            DBConnection.Execute(sql);               ///////////   how tם deal with the response?
        }

             
        public void DeleteAgent(int agentId)
        {
            string sql = $"DELETE FROM agents WHERE Id = {agentId}";

            DBConnection.Execute(sql);                                 ///////////   how tם deal with the response?
        }
    }


}
