using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APM.Repository
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public List<ConstantDto> GetList()
        {
            return _context.Titles.Select(t => new ConstantDto { ID = t.ID, NAME = t.TITLE_NAME }).ToList();
        }
        public void DeleteTitle(int id)
        {
            var title = _context.Titles.FirstOrDefault(t => t.ID == id);
            _context.Titles.Remove(title);
            _context.SaveChanges();
        }


        public ConstantDto Get(int id)
        {
            var t = _context.Titles.FirstOrDefault(t => t.ID == id);
            return new ConstantDto { ID = t.ID, NAME = t.TITLE_NAME };
        }

        public void Create(ConstantDto title)
        {
            _context.Titles.Add(new Title { ID = title.ID, TITLE_NAME = title.NAME });
            _context.SaveChanges();
        }

        public void Update(ConstantDto title)
        {
            _context.Titles.Update(new Title { ID = title.ID, TITLE_NAME = title.NAME });
            _context.SaveChanges();
        }
    }
}
