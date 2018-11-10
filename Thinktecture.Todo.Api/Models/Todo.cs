using System;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Thinktecture.Todo.Api.Models
{
    public class Todo : ISyncItem
    {
        public bool Completed { get; set; }
        public string Text { get; set; }
        
        public Guid? SyncId { get; set; }
        public bool Deleted { get; set; }
        public bool Changed { get; set; }
    }
}