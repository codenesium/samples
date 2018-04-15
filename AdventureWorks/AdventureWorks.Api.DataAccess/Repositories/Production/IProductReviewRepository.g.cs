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

		ApiResponse GetById(int productReviewID);

		POCOProductReview GetByIdDirect(int productReviewID);

		ApiResponse GetWhere(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductReview> GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>587fd151f88575c2ae5f702732a8824e</Hash>
</Codenesium>*/