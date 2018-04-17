using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBODocument
	{
		Task<CreateResponse<Guid>> Create(
			DocumentModel model);

		Task<ActionResponse> Update(Guid documentNode,
		                            DocumentModel model);

		Task<ActionResponse> Delete(Guid documentNode);

		ApiResponse GetById(Guid documentNode);

		POCODocument GetByIdDirect(Guid documentNode);

		ApiResponse GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dfe3b56bc1aeaaa796950b1e4b028e70</Hash>
</Codenesium>*/