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

        public async Task<IEnumerable<Coach>> BrowseAllAsync()
        {
            return await Task.FromResult(_CoachMock);
        }

        public async Task DelAsync(Coach c)
        {
            int x = _CoachMock.FindIndex(x => x.Id == c.Id);
            if(x!=-1)
            {
                _CoachMock.RemoveAt(x);
            }
            await Task.CompletedTask;
        }

        public async Task<Coach> GetAsync(int id)
        {
            return await Task.FromResult(_CoachMock.Find(x => x.Id == id));
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
