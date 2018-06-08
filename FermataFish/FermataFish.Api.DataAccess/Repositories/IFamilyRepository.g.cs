using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IFamilyRepository
        {
                Task<Family> Create(Family item);

                Task Update(Family item);

                Task Delete(int id);

                Task<Family> Get(int id);

                Task<List<Family>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>33d7a83592b846a7cad027d2d85e8bc7</Hash>
</Codenesium>*/