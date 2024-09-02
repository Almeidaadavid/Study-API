﻿using API.Domain.DTOs;
using System.Reflection;

namespace API.Domain.Model
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        List<EmployeeDTO> Get();
        EmployeeDTO Get(int id);
    }
}
