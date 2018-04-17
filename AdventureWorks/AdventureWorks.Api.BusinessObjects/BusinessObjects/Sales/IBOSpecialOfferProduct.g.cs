using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSpecialOfferProduct
	{
		Task<CreateResponse<int>> Create(
			SpecialOfferProductModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            SpecialOfferProductModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		ApiResponse GetById(int specialOfferID);

		POCOSpecialOfferProduct GetByIdDirect(int specialOfferID);

		ApiResponse GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>de1ca13855ab0bb7e782108f07380d4b</Hash>
</Codenesium>*/