using System;
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
        //private AppDbContext _appDbContext;

        //Sprawdzanie poprawności dodawanych miast leży po stronie service

        private List<City> _citiesMock = new List<City>();

        public async Task AddAsync(City c)
        {
            int index = _citiesMock.FindIndex(item => item.Id == c.Id);
            if (index < 0 && c.Id > 0)
            {
                _citiesMock.Add(c);
            }
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<City>> BrowseAllAsync()
        {
            return await Task.FromResult(_citiesMock);
        }

        public async Task DelAsync(City c)
        {
            int index = _citiesMock.FindIndex(item => item.Id == c.Id);
            if(index >= 0)
            {
                _citiesMock.RemoveAt(index);
            }
            await Task.CompletedTask;
        }

        public async Task<City> GetAsync(int id)
        {

            return await Task.FromResult(_citiesMock.Find(item => item.Id == id));

        }

        public async Task UpdateAsync(City c)
        {
            //Dodanie update async
            int index = _citiesMock.FindIndex(item => item.Id == c.Id);
            if(index >= 0)
            {
                _citiesMock[index] = c;
            }

            await Task.CompletedTask;
        }
    }
}
