using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface IPostHistoryRepository
        {
                Task<PostHistory> Create(PostHistory item);

                Task Update(PostHistory item);

                Task Delete(int id);

                Task<PostHistory> Get(int id);

                Task<List<PostHistory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c0bdaf895ccd27a6902bc8d1346f2688</Hash>
</Codenesium>*/