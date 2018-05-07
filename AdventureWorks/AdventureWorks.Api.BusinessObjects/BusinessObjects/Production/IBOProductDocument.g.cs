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

		POCOProductDocument Get(int productID);

		List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5204791f17a18ed54300f6f7e1fa780d</Hash>
</Codenesium>*/