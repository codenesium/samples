using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IRateRepository
        {
                Task<Rate> Create(Rate item);

                Task Update(Rate item);

                Task Delete(int id);

                Task<Rate> Get(int id);

                Task<List<Rate>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2c24a114d8a27609fa1d8ecdea867172</Hash>
</Codenesium>*/