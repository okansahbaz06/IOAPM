using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APM.Repository
{
    public class PriorityRepository : GenericRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(IUnitOfWork uow)
    : base(uow)
        {

        }
        public List<ConstantDto> GetList()
        {
            return _context.Priorities.Select(p => new ConstantDto { ID = p.ID, NAME = p.PRIORITY_NAME }).ToList();
        }
        public ConstantDto Get(int id)
        {
            var t = _context.Priorities.FirstOrDefault(t => t.ID == id);
            return new ConstantDto { ID = t.ID, NAME = t.PRIORITY_NAME };
        }
        public void DeletePriority(int id)
        {
            var p = _context.Priorities.FirstOrDefault(t => t.ID == id);
            _context.Priorities.Remove(p);
            _context.SaveChanges();
        }

        public void Create(ConstantDto priority)
        {
            _context.Priorities.Add(new Priority { ID = priority.ID, PRIORITY_NAME = priority.NAME });
            _context.SaveChanges();
        }

        public void Update(ConstantDto priority)
        {
            _context.Priorities.Update(new Priority { ID = priority.ID, PRIORITY_NAME = priority.NAME });
            _context.SaveChanges();
        }
    }
}
