using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		int Create(int productID,
		           string reviewerName,
		           DateTime reviewDate,
		           string emailAddress,
		           int rating,
		           string comments,
		           DateTime modifiedDate);

		void Update(int productReviewID, int productID,
		            string reviewerName,
		            DateTime reviewDate,
		            string emailAddress,
		            int rating,
		            string comments,
		            DateTime modifiedDate);

		void Delete(int productReviewID);

		Response GetById(int productReviewID);

		POCOProductReview GetByIdDirect(int productReviewID);

		Response GetWhere(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductReview> GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d586043a9c0ad0a7a4c17a5831daada2</Hash>
</Codenesium>*/