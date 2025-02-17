using ProjectInfoTecs.Models;
using System.Collections.Concurrent;
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
        }
    
}
