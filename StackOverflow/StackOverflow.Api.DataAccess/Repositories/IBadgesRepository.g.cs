using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface IBadgesRepository
        {
                Task<Badges> Create(Badges item);

                Task Update(Badges item);

                Task Delete(int id);

                Task<Badges> Get(int id);

                Task<List<Badges>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>744a3bfc01ebe6c7c723bee502c54ad1</Hash>
</Codenesium>*/