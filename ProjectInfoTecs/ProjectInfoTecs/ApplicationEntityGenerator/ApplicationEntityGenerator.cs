using ProjectInfoTecs.Models;
using System.Xml.Linq;
namespace ProjectInfoTecs.ApplicationEntityGenerator
{
    public class ApplicationEntityGenerator
    {
        List<string> names = new List<string>
        {
            "John Doe",
            "Jane Smith",
            "Alice Johnson",
        
        };

        List<DateTime> startTimes = new List<DateTime>
        {
            new DateTime(1980, 1, 2),
            new DateTime(1990, 5, 15),
            new DateTime(2000, 10, 20)
        };

        List<DateTime> endTimes = new List<DateTime>
        {
            new DateTime(1980, 1, 4),
            new DateTime(1990, 5, 17),
            new DateTime(2000, 10, 22)
        };

        List<string> versions = new List<string>
        {
            "1.0.0.56",
            "2.1.3.78",
            "3.4.5.12"
        };

        Random random = new Random();
        
        public  ApplicationEntity getNewEntity()
        {


            ApplicationEntity entity = new ApplicationEntity();
            entity._id = Guid.NewGuid();
            entity.version = versions[random.Next(versions.Count)];
            entity.startTime = startTimes[random.Next(startTimes.Count)];
            entity.endTime = endTimes[random.Next(endTimes.Count)];
            entity.name = names[random.Next(names.Count)];
            return entity;
        }


    }
}
