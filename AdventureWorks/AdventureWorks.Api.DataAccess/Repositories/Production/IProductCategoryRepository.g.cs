using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		Task<DTOProductCategory> Create(DTOProductCategory dto);

		Task Update(int productCategoryID,
		            DTOProductCategory dto);

		Task Delete(int productCategoryID);

		Task<DTOProductCategory> Get(int productCategoryID);

		Task<List<DTOProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOProductCategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>528759584c29daba40d3cccca530ae5e</Hash>
</Codenesium>*/