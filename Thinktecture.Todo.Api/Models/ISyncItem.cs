using System;
// ReSharper disable UnusedMemberInSuper.Global

namespace Thinktecture.Todo.Api.Models
{
    public interface ISyncItem
    {
        Guid? SyncId { get; set; }
        bool Deleted { get; set; }
        bool Changed { get; set; }
    }
}