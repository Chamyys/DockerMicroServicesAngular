using ProjectInfoTecs.Models;
using System.Collections.Concurrent;
using System.Text.Json;
namespace ProjectInfoTecs.ItemService
{
    
        public class ItemService : IItemService
    {
            private readonly List<ApplicationEntity> _items = new List<ApplicationEntity>();
        int maxCopacity = 10;
            public void AddItem(ApplicationEntity item)
            {
            if (_items.Count < maxCopacity)
            {
                _items.Add(item);
            }
            }
        public void RemoveItem(ApplicationEntity item)
        {
        
                _items.Remove(_items.FirstOrDefault(element => element._id == item._id));
            
        }
            public List<ApplicationEntity> GetItems()
            {
                return _items;
            }
        public void BackUp()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                string formattedDateTime = dateTime.ToString("yyyy-MM-dd_HH-mm-ss");
                string fileName = $"Backup{formattedDateTime}.json";
                string relativePath = @"..\..\";
                string fullPath = Path.Combine(relativePath, fileName);
                StreamWriter sw = new StreamWriter(fullPath);
                foreach ( ApplicationEntity item in _items )
                {
                    sw.Write(JsonSerializer.Serialize(item));
                    sw.WriteLine('\n');
                }
                

            
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        }
    
}
