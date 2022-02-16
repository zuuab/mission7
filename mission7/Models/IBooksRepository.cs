using System;
using System.Linq;

namespace mission7.Models
{
    public interface IBooksRepository
    {
        IQueryable<Books> Books { get; }
    }
}
