﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repository;

namespace Zawodnicy.Infrastructure.Repositories
{
    class CitiesRepository : ICitiesRepository
    {
        private AppDbContext _appDbContext;

        public CitiesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddSync(City c)
        {
            try
            {
                _appDbContext.City.Add(c);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            } 
        }

    public Task<IEnumerable<City>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(City c)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetAsync(int id)
        {
            try
            {
                return await Task.FromResult(_appDbContext.City.FirstOrDefault(x => x.Id == id));

            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public Task UpdateAsync(City c)
        {
            throw new NotImplementedException();
        }
    }
}
