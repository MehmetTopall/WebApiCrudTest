using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeDal = employeeDal;
        }
        public void Add(Employee entity)
        {
            _employeDal.Add(entity);
        }

        public void Delete(int id)
        {
            _employeDal.Delete(id);
        }

        public List<Employee> GetAll()
        {
            return _employeDal.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeDal.GetById(id);
        }

        public void Update(Employee entity)
        {
            _employeDal.Update(entity);
        }
    }
}
