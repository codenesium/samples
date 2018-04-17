using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSpecialOffer
	{
		Task<CreateResponse<int>> Create(
			SpecialOfferModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            SpecialOfferModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		ApiResponse GetById(int specialOfferID);

		POCOSpecialOffer GetByIdDirect(int specialOfferID);

		ApiResponse GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b156a4cdfe703b440d7192d01d44c250</Hash>
</Codenesium>*/