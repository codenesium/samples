using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCreditCard
	{
		Task<CreateResponse<int>> Create(
			CreditCardModel model);

		Task<ActionResponse> Update(int creditCardID,
		                            CreditCardModel model);

		Task<ActionResponse> Delete(int creditCardID);

		ApiResponse GetById(int creditCardID);

		POCOCreditCard GetByIdDirect(int creditCardID);

		ApiResponse GetWhere(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCreditCard> GetWhereDirect(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>50a545b6a01016200a84230259ebcf02</Hash>
</Codenesium>*/