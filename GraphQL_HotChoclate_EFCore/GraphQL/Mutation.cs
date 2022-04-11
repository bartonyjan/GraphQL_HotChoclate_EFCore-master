using GraphQL_HotChoclate_EFCore.Models;
using GraphQL_HotChoclate_EFCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.GraphQL
{
    public class Mutation
    {
        #region Property
        private readonly IEmployeeService _employeeService;

        private readonly ILocationService _locationService;
        #endregion

        #region Constructor
        public Mutation(IEmployeeService employeeService, ILocationService locationSrvice)
        {
            _employeeService = employeeService;
            _locationService = locationSrvice;
        }
        #endregion
        public async Task<Employee> Create(int id, string name, string designation) => await _employeeService.Create(new Employee() { Id = id, Name = name, Designation = designation });
        public async Task<Employee> Delete(int id) => await _employeeService.Delete(id);

        public async Task<Location> CreateLocation(Location location) => await _locationService.Create(location);
        public async Task<bool> DeleteLocation(int id) => await _locationService.Delete(id);
    }
}
