using AmazingNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingNotesApp.DataAccess
{
    public class ItemRepository
    {
        protected AmazingNotesContext db;

        public ItemRepository(AmazingNotesContext db)
        {
            this.db = db;
        }

        public void Create(Item item)
        {
            db.Set<Item>().Add(item);
        }

        public void Delete(Guid id)
        {
            db.Set<Item>().Remove(Read(id));
        }

        public Item Read(Guid id)
        {
            return db.Set<Item>().Find(id);
        }

        public IEnumerable<Item> ReadAll()
        {
            return db.Set<Item>();
        }

        public void Update(Item item)
        {
            db.Set<Item>().Update(item);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
