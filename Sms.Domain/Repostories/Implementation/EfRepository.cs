﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;
using Sms.Domain.Repostories.Interfaces;

namespace Sms.Domain.Repostories.Implementation
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        private readonly SmsDbContext _dbContext;
        private readonly IMapper _mapper;

        public EfRepository(SmsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }


        public virtual async Task<TViewModel> GetByIdAsync<TViewModel>(int id)
        {
            var model = await _dbContext.Set<T>().FindAsync(id);
            return _mapper.Map<TViewModel>(model);
        }

        public virtual async Task<TViewModel> GetSingleAsync<TViewModel>(ISpecification<T> spec)
        {
            var queryable = _dbContext.Set<T>().AsQueryable();
            if (spec.Criteria != null)
                queryable = queryable.Where(spec.Criteria).AsQueryable();

            var queryableResultWithIncludes = spec.Includes
                .Aggregate(queryable,
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return await secondaryResult.ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<List<TViewModel>> ListAllAsync<TViewModel>()
        {
            return await _dbContext.Set<T>()
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }
        public async Task<List<TViewModel>> ListAsync<TViewModel>(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            if (spec.Criteria != null)
                // return the result of the query using the specification's criteria expression
                return await secondaryResult
                                .Where(spec.Criteria)
                                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                                .ToListAsync();
            return await secondaryResult
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        //public bool Complete()
        //{
        //    return _dbContext.SaveChanges() > 0;
        //}

        //public async Task<bool> CompleteAsync()
        //{
        //    return await _dbContext.SaveChangesAsync() > 0;
        //}
    }
}
