using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductDocument
	{
		Task<CreateResponse<int>> Create(
			ProductDocumentModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductDocumentModel model);

		Task<ActionResponse> Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductDocument GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductDocument> GetWhereDirect(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d4bf9b97346200a91c667bb5a1158fb6</Hash>
</Codenesium>*/