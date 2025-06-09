﻿


namespace CSharpAndSQL.models
{
    public class Agent
    {
       public int Id { get; set; }
       public string CodeName { get; set; }
       public  string RealName { get; set; }
       public string Location { get; set; }
       public string Status { get; set; }
       public int MissionsCompleted { get; set; }

        public Agent(int id, string codeName, string realName, string location, string status, int missionsCompleted)
        {
            this.Id = id;
            this.CodeName = codeName;
            this.RealName = realName;
            this.Location = location;
            this.Status = status;
            this.MissionsCompleted = missionsCompleted;
        }
       
    }


}
