using GraphQL_HotChoclate_EFCore.Models;
using GraphQL_HotChoclate_EFCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.GraphQL
{
    public class Mutuation
    {
        #region Property
        private readonly IEmployeeService _employeeService;

        private readonly ILocationService _locationService;
        #endregion

        #region Constructor
        public Mutuation(IEmployeeService employeeService, ILocationService locationSrvice)
        {
            _employeeService = employeeService;
            _locationService = locationSrvice;
        }
        #endregion
        public async Task<Employee> Create(Employee employee) => await _employeeService.Create(employee);
        public async Task<bool> Delete(int id) => await _employeeService.Delete(id);

        public async Task<Location> CreateLocation(Location location) => await _locationService.Create(location);
        public async Task<bool> DeleteLocation(int id) => await _locationService.Delete(id);
    }
}
