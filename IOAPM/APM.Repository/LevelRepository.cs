using APM.Entities.Entities;
using APM.Repository;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System.Collections.Generic;
using System.Linq;

namespace APM.Repository
{
    public class LevelRepository : GenericRepository<Level>, ILevelRepository
    {
        public LevelRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public List<ConstantDto> GetList()
        {
            return _context.Levels.OrderBy(l => l.i).Select(p => new ConstantDto { ID = p.ID, NAME = p.LEVEL_NAME, i = p.i }).ToList();
        }
        public ConstantDto Get(int id)
        {
            var level = _context.Levels.FirstOrDefault(t => t.ID == id);
            return new ConstantDto { ID = level.ID, NAME = level.LEVEL_NAME, i = level.i };
        }
        public void DeleteLevel(int id)
        {
            var level = _context.Levels.FirstOrDefault(level => level.ID == id);
            _context.Levels.Remove(level);
            _context.SaveChanges();
        }

        public void Create(ConstantDto level)
        {
            var i = _context.Levels.Max(l => l.i);
            if (i == 0)
                i = 1;
            else
                i++;

            _context.Levels.Add(new Level { ID = level.ID, LEVEL_NAME = level.NAME, i = i });
            _context.SaveChanges();
        }

        public void Update(ConstantDto level)
        {
            var update = _context.Levels.FirstOrDefault(l => l.ID == level.ID);
            update.LEVEL_NAME = level.NAME;

            _context.Levels.Update(update);
            _context.SaveChanges();
        }
    }
}
