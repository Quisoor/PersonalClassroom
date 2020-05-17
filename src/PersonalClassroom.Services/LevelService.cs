using AutoMapper;
using PersonalClassroom.Database;
using PersonalClassroom.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services
{
    public class LevelService
    {
        private readonly PcContext context;
        private readonly IMapper mapper;

        public LevelService(PcContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<ShortModel> Get()
        {
            var query = context.Levels.AsQueryable();
            return mapper.ProjectTo<ShortModel>(query);
        }

        public async Task<IEnumerable<ShortModel>> GetAsync(CancellationToken cancellationToken)
        {
            var query = context.Levels.AsQueryable();
            return await Task.Run(() => mapper.ProjectTo<ShortModel>(query), cancellationToken);
        }
    }
}
