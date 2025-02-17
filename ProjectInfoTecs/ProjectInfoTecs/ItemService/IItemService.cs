using ProjectInfoTecs.Models;
using System.Collections.Concurrent;
namespace ProjectInfoTecs.ItemService
{
  

    public interface IItemService
    {
        void AddItem(ApplicationEntity entity);
        void RemoveItem(ApplicationEntity entity);
        List<ApplicationEntity> GetItems();
    }

   
}
