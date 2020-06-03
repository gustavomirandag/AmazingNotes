using AmazingNotesApp.DataAccess;
using AmazingNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AmazingNotesApp.Service
{
    public class ItemService
    {
        private readonly ItemRepository itemRepository;

        public ItemService(ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void CreateItem(Item item)
        {
            itemRepository.Create(item);
            itemRepository.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            return itemRepository.ReadAll();
        }

        public Item GetItemById(Guid id)
        {
            return itemRepository.Read(id);
        }

        public void UpdateItem(Item item)
        {
            itemRepository.Update(item);
            itemRepository.SaveChanges();
        }

        public void DeleteItem (Guid id)
        {
            itemRepository.Delete(id);
            itemRepository.SaveChanges();
        }
    }
}
