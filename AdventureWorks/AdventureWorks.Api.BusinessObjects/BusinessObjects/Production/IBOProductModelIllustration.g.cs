using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModelIllustration
	{
		Task<CreateResponse<int>> Create(
			ProductModelIllustrationModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ProductModelIllustrationModel model);

		Task<ActionResponse> Delete(int productModelID);

		ApiResponse GetById(int productModelID);

		POCOProductModelIllustration GetByIdDirect(int productModelID);

		ApiResponse GetWhere(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModelIllustration> GetWhereDirect(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>da8080158f1a3bd2c40a86cfcd420356</Hash>
</Codenesium>*/