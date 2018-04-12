using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		int Create(
			int productID,
			string reviewerName,
			DateTime reviewDate,
			string emailAddress,
			int rating,
			string comments,
			DateTime modifiedDate);

		void Update(int productReviewID,
		            int productID,
		            string reviewerName,
		            DateTime reviewDate,
		            string emailAddress,
		            int rating,
		            string comments,
		            DateTime modifiedDate);

		void Delete(int productReviewID);

		Response GetById(int productReviewID);

		POCOProductReview GetByIdDirect(int productReviewID);

		Response GetWhere(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductReview> GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>928a8569f34e867d98492dc116033648</Hash>
</Codenesium>*/