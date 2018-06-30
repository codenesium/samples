using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface IVotesRepository
        {
                Task<Votes> Create(Votes item);

                Task Update(Votes item);

                Task Delete(int id);

                Task<Votes> Get(int id);

                Task<List<Votes>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9c1ed96a1312398e13d3c4b18bab384e</Hash>
</Codenesium>*/