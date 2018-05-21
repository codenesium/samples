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
		Task<CreateResponse<POCOProductDocument>> Create(
			ApiProductDocumentModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductDocumentModel model);

		Task<ActionResponse> Delete(int productID);

		Task<POCOProductDocument> Get(int productID);

		Task<List<POCOProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cdd969c89346e866d314cf6d10fdc3ef</Hash>
</Codenesium>*/