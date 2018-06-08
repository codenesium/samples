using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IOtherTransportRepository
        {
                Task<OtherTransport> Create(OtherTransport item);

                Task Update(OtherTransport item);

                Task Delete(int id);

                Task<OtherTransport> Get(int id);

                Task<List<OtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e1f0cede71f15445778e1ad748d29b19</Hash>
</Codenesium>*/