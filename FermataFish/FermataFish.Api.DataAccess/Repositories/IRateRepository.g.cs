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

                Task<List<Rate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f0bad229d1bb943bf22f526395647631</Hash>
</Codenesium>*/