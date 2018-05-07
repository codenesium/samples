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

		POCOProductReview Get(int productReviewID);

		List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dde831624646121d127fe47469419364</Hash>
</Codenesium>*/