using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IDestinationRepository
        {
                Task<Destination> Create(Destination item);

                Task Update(Destination item);

                Task Delete(int id);

                Task<Destination> Get(int id);

                Task<List<Destination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>44d1f1f8e1bc2ef978e0980c06dadd75</Hash>
</Codenesium>*/