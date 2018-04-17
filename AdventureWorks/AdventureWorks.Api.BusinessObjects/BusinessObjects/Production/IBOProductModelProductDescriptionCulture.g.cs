using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModelProductDescriptionCulture
	{
		Task<CreateResponse<int>> Create(
			ProductModelProductDescriptionCultureModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ProductModelProductDescriptionCultureModel model);

		Task<ActionResponse> Delete(int productModelID);

		ApiResponse GetById(int productModelID);

		POCOProductModelProductDescriptionCulture GetByIdDirect(int productModelID);

		ApiResponse GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModelProductDescriptionCulture> GetWhereDirect(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bd1b096fbfca77d50b7589553ad5f73c</Hash>
</Codenesium>*/