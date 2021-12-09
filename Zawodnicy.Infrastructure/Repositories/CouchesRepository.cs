using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repository;

namespace Zawodnicy.Infrastructure.Repositories
{
    class CouchesRepository : ICoachesRepository
    {
        public static List<Coach> _CoachMock = new List<Coach>();

        public async Task AddSync(Coach c)
        {
            _CoachMock.Add(c);
            await Task.CompletedTask;
        }

        public Task<IEnumerable<Coach>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Coach c)
        {
           if(_CoachMock.Remove(c))
            {
                await Task.CompletedTask;
            }
        }

        public Task<Coach> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Coach c)
        {
            int idx = _CoachMock.FindIndex(x => x.Id == c.Id);

            if (idx != -1)
            {
                _CoachMock[idx] = c;
            }
            await Task.CompletedTask;
        }
    }
}
