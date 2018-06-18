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

                Task<List<Culture>> All(int limit = int.MaxValue, int offset = 0);

                Task<Culture> ByName(string name);

                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(string cultureID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5b5c3c48b32b813e020549f0b1010a14</Hash>
</Codenesium>*/