using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface ITimestampCheckRepository
        {
                Task<TimestampCheck> Create(TimestampCheck item);

                Task Update(TimestampCheck item);

                Task Delete(int id);

                Task<TimestampCheck> Get(int id);

                Task<List<TimestampCheck>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d740e94a161e597abd518e99cb24e41c</Hash>
</Codenesium>*/