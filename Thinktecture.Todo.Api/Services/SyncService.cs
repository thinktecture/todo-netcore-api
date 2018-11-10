using System;
using System.Collections.Generic;

namespace Thinktecture.Todo.Api.Services
{
    public class SyncService
    {
        private readonly List<Models.Todo> _items = new List<Models.Todo>();
        
        public List<Models.Todo> Sync(List<Models.Todo> items)
        {
            items.ForEach(syncItem =>
            {
                var index = _items.FindIndex(item => item.SyncId == syncItem.SyncId);
                if (index >= 0)
                {
                    if (syncItem.Changed || syncItem.Deleted)
                    {
                        syncItem.Changed = false;
                        _items[index] = syncItem;
                    }
                }
                else
                {
                    if (syncItem.SyncId == null)
                    {
                        syncItem.SyncId = Guid.NewGuid();
                        syncItem.Changed = false;
                    }

                    _items.Add(syncItem);
                }
            });

            return _items;
        }

        public void ResetItems()
        {
            _items.Clear();
            _items.Add(new Models.Todo
            {
                SyncId = new Guid("11e94ce4-e717-41d5-9a67-e70331cd7a42"),
                Deleted = false,
                Changed = false,
                Completed = false,
                Text = "Prepare demo"
            });
            _items.Add(new Models.Todo
            {
                SyncId = new Guid("60d09e91-651d-41d3-bc6b-5500cbcc53bf"),
                Deleted = false,
                Changed = false,
                Completed = false,
                Text = "Prepare slides"
            });
        }
    }
}