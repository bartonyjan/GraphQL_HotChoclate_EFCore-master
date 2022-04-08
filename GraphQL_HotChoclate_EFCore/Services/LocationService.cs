using GraphQL_HotChoclate_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_HotChoclate_EFCore.Services
{
    public class LocationService : ILocationService
    {
        #region Property
        private readonly DatabaseContext _dbContext;
        #endregion

        #region Constructor
        public LocationService(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        #endregion

        public Location GetLocation(int id)
        {
            return _dbContext.Locations.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Location> GetAll()
        {
            return _dbContext.Locations.AsQueryable();
        }

        public async Task<Location> Create(Location location)
        {
            var data = new Location
            {
                Name = location.Name,
                City = location.Address,
                Address = location.Address
            };
            await _dbContext.Locations.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }
        public async Task<bool> Delete(int id)
        {
            var location = await  _dbContext.Locations.FirstOrDefaultAsync(c => c.Id == id);
            if(location is not null) 
            {
                _dbContext.Locations.Remove(location);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
