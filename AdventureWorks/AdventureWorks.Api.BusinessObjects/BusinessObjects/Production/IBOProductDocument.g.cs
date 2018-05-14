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

		POCOProductDocument Get(int productID);

		List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>27602bb562346b8b99c4aa6e816d3eab</Hash>
</Codenesium>*/