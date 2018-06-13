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

                Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>09645e704e2d526199957c4bf5cfbf31</Hash>
</Codenesium>*/