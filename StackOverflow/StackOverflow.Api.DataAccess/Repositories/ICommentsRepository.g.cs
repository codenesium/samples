using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface ICommentsRepository
        {
                Task<Comments> Create(Comments item);

                Task Update(Comments item);

                Task Delete(int id);

                Task<Comments> Get(int id);

                Task<List<Comments>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0e2bdf0c91f2a4f027197fd3bb245cfc</Hash>
</Codenesium>*/