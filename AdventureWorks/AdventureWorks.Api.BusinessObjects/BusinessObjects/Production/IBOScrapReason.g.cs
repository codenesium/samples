using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOScrapReason
	{
		Task<CreateResponse<short>> Create(
			ScrapReasonModel model);

		Task<ActionResponse> Update(short scrapReasonID,
		                            ScrapReasonModel model);

		Task<ActionResponse> Delete(short scrapReasonID);

		ApiResponse GetById(short scrapReasonID);

		POCOScrapReason GetByIdDirect(short scrapReasonID);

		ApiResponse GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1a7182450b482fc889dedb2889d302bf</Hash>
</Codenesium>*/