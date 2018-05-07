using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		int Create(ProductReviewModel model);

		void Update(int productReviewID,
		            ProductReviewModel model);

		void Delete(int productReviewID);

		POCOProductReview Get(int productReviewID);

		List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b98f7556c5ae5dc1cf02df3fba2fde8c</Hash>
</Codenesium>*/