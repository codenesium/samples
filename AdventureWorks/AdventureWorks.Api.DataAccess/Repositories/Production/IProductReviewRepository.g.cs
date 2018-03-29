using System;
using System.Linq.Expressions;
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

		void GetById(int productReviewID, Response response);

		void GetWhere(Expression<Func<EFProductReview, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bdd2c561530642d9b20bac2a215bf4c1</Hash>
</Codenesium>*/