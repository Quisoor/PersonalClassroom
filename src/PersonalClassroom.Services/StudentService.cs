using AutoMapper;
using PersonalClassroom.Database;
using PersonalClassroom.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services
{
    public class StudentService
    {
        private readonly PcContext context;
        private readonly IMapper mapper;

        public StudentService(PcContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<ShortModel> Get()
        {
            var query = context.Students.OrderBy(x => x.Firstname);
            return mapper.ProjectTo<ShortModel>(query);
        }

        public async Task<IEnumerable<ShortModel>> GetAsync(CancellationToken cancellationToken)
        {
            var query = context.Students.OrderBy(x => x.Firstname);
            return await Task.Run(() => mapper.ProjectTo<ShortModel>(query), cancellationToken);
        }

        public IEnumerable<ShortModel> Get(IEnumerable<int> ids)
        {
            var query = context.Students
                .OrderBy(x => x.Firstname)
                .Where(x => ids.Contains(x.Id));
            return mapper.ProjectTo<ShortModel>(query);
        }
    }
}
