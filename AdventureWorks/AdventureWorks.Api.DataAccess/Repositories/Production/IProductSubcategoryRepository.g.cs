using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		Task<DTOProductSubcategory> Create(DTOProductSubcategory dto);

		Task Update(int productSubcategoryID,
		            DTOProductSubcategory dto);

		Task Delete(int productSubcategoryID);

		Task<DTOProductSubcategory> Get(int productSubcategoryID);

		Task<List<DTOProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOProductSubcategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>71a0e65ec0986437dcc426aecb332aec</Hash>
</Codenesium>*/