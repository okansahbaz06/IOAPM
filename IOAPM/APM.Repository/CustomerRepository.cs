using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System.Linq;

namespace APM.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public void Update(CustomerDto customer)
        {
            _context.Customers.Update(new Customer
            {
                ID = customer.ID,
                CUSTOMER_NAME = customer.NAME,
                CUSTOMER_TYPE = customer.TYPE,
                CUSTOMER_PHONE_NO = customer.PHONE_NO,
                CUSTOMER_ADRESS = customer.ADRESS,
                CUSTOMER_MAIL = customer.MAIL,
                CUSTOMER_STATUS = customer.STATUS,
                CUSTOMER_CREATOR = customer.CREATOR_ID
            });
            _context.SaveChanges();
        }
        public void Create(CustomerDto customer)
        {
            _context.Customers.Add(new Customer
            {
                ID = customer.ID,
                CUSTOMER_NAME = customer.NAME,
                CUSTOMER_TYPE = customer.TYPE,
                CUSTOMER_PHONE_NO = customer.PHONE_NO,
                CUSTOMER_ADRESS = customer.ADRESS,
                CUSTOMER_MAIL = customer.MAIL,
                CUSTOMER_STATUS = customer.STATUS,
                CUSTOMER_CREATOR = customer.CREATOR_ID
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.ID == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        public CustomerEmployeeDto GetList()
        {
            var customer = _context.Customers.Select(c => new CustomerDto
            {
                ID = c.ID,
                TYPE = c.CUSTOMER_TYPE,
                NAME = c.CUSTOMER_NAME,
                PHONE_NO = c.CUSTOMER_PHONE_NO,
                ADRESS = c.CUSTOMER_ADRESS,
                MAIL = c.CUSTOMER_MAIL,
                STATUS = c.CUSTOMER_STATUS,
                CREATOR_ID = c.CUSTOMER_CREATOR,
                CREATED_DATE = c.CREATED_DATE,
                CREATED_TIME = c.CREATED_TIME,
                CREATED_CUSTOMER = c.CREATED_CUSTOMER
            }).ToList();
            var employee = _context.Employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME
            }).ToList();

            return new CustomerEmployeeDto { EmployeeDto = employee, CustomerDto = customer };
        }
    }
}
