using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APM.Repository
{
    public class ProjectTypeRepository : GenericRepository<Project_Type>, IProjectTypeRepository
    {
        public ProjectTypeRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public List<ConstantDto> GetList()
        {
            return _context.Project_Types.Select(p => new ConstantDto { ID = p.ID, NAME = p.TYPE_NAME }).ToList();
        }
        public ConstantDto Get(int id)
        {
            var p = _context.Project_Types.FirstOrDefault(p => p.ID == id);
            return new ConstantDto { ID = p.ID, NAME = p.TYPE_NAME };
        }
        public void DeleteProjectType(int id)
        {
            var p = _context.Project_Types.FirstOrDefault(t => t.ID == id);
            _context.Project_Types.Remove(p);
            _context.SaveChanges();
        }

        public void Create(ConstantDto type)
        {
            _context.Project_Types.Add(new Project_Type { ID = type.ID, TYPE_NAME = type.NAME });
            _context.SaveChanges();
        }

        public void Update(ConstantDto type)
        {
            _context.Project_Types.Update(new Project_Type { ID = type.ID, TYPE_NAME = type.NAME });
            _context.SaveChanges();
        }
    }
}
