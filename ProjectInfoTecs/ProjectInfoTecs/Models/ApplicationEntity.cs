namespace ProjectInfoTecs.Models
{
    public class ApplicationEntity : Entity
    {
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string version { get; set; }

        public ApplicationEntity()
        {
            _id = Guid.NewGuid();
            name = "Error";
            startTime = DateTime.MinValue; 
            endTime = DateTime.MinValue;  
            version = "Error";
        }
    }
}
 