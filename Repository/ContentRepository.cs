using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CmsLocalization.DB;
using CmsLocalization.Infastructure;
using Microsoft.EntityFrameworkCore;

namespace CmsLocalization.Repository
{
public class ContentRepository : IContentRepository
    {
        private readonly IContentMappingRepository _contentMappingRepository;

        private readonly CMS_Context _context;

        public ContentRepository(CMS_Context context,
               IContentMappingRepository contentMappingRepository)
        {
            _context = context;
            _contentMappingRepository = contentMappingRepository;
        }

        public Content GetById(int id)
        {
            var content = _context.Contents
                .Where(c => c.Id == id)
                .Include(c => c.Locales)
                .FirstOrDefault();
            return content;
        }

        public IEnumerable<Content> GetAll()
        {
            return _context.Contents.Include(c => c.Locales).ToList();
        }

        public IQueryable<Content> GetMany(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Include(c => c.Locales).Where(expression);
        }

        public Content Get(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Include(c => c.Locales).Where(expression).FirstOrDefault();
        }

        public void Insert(Content entity)
        {
            entity.CreatedTime = DateTime.Now;
            _context.Contents.Add(entity);
        }

        public int InsertAndGetId(Content entity)
        {
            entity.CreatedTime = DateTime.Now;
            _context.Contents.Add(entity);
            Save();
            return entity.Id;
        }

        public void Update(Content entity)
        {
            Save();
        }
        public void Delete(Content entity)
        {
            _context.Remove(entity);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}