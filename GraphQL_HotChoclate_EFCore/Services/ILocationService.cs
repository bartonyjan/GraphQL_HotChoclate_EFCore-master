using GraphQL_HotChoclate_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.Services
{
   public interface ILocationService
    {
        Task<Location> Create(Location location);
        Task<bool> Delete(int id);
        IQueryable<Location> GetAll();

        Location GetLocation(int id);
    }
}
