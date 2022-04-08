using GraphQL_HotChoclate_EFCore.Models;
using GraphQL_HotChoclate_EFCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.GraphQL
{
    public class Query
    {
        #region Property
        private readonly IEmployeeService _employeeService;

        private readonly ILocationService _locationService;
        #endregion

        #region Constructor
        public Query(IEmployeeService employeeService, ILocationService locationSrvice)
        {
            _employeeService = employeeService;
            _locationService = locationSrvice;
        }
        #endregion

        public IQueryable<Employee> Employees => _employeeService.GetAll();

        public Employee Employee(int id) =>_employeeService.GetEmployee(id);

        public IQueryable<Location> Locations => _locationService.GetAll();

        public Location Location(int id) => _locationService.GetLocation(id);
    }
}
