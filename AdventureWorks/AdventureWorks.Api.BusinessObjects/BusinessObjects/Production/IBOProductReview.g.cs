using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductReview
	{
		Task<CreateResponse<int>> Create(
			ProductReviewModel model);

		Task<ActionResponse> Update(int productReviewID,
		                            ProductReviewModel model);

		Task<ActionResponse> Delete(int productReviewID);

		ApiResponse GetById(int productReviewID);

		POCOProductReview GetByIdDirect(int productReviewID);

		ApiResponse GetWhere(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductReview> GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae2069e7b84fa2e9954589d74926e1ee</Hash>
</Codenesium>*/