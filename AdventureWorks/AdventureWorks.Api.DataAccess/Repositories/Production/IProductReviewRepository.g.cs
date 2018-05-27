using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		Task<DTOProductReview> Create(DTOProductReview dto);

		Task Update(int productReviewID,
		            DTOProductReview dto);

		Task Delete(int productReviewID);

		Task<DTOProductReview> Get(int productReviewID);

		Task<List<DTOProductReview>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOProductReview>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>ea172d29509a414e3b72328d7e9e9f43</Hash>
</Codenesium>*/