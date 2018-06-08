using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICultureRepository
        {
                Task<Culture> Create(Culture item);

                Task Update(Culture item);

                Task Delete(string cultureID);

                Task<Culture> Get(string cultureID);

                Task<List<Culture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Culture> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>8f8227389abdc067d1d8aa1f4be5700b</Hash>
</Codenesium>*/