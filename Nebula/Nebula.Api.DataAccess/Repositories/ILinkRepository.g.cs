using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkRepository
        {
                Task<Link> Create(Link item);

                Task Update(Link item);

                Task Delete(int id);

                Task<Link> Get(int id);

                Task<List<Link>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>0245ac53aec44f21cf3803df99635c79</Hash>
</Codenesium>*/