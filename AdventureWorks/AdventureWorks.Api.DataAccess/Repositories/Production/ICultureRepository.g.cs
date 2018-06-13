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

                Task<List<Culture>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Culture> GetName(string name);

                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(string cultureID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2780985dc47f26965ba95ea210185ddb</Hash>
</Codenesium>*/