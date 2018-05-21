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
		Task<CreateResponse<POCODocument>> Create(
			ApiDocumentModel model);

		Task<ActionResponse> Update(Guid documentNode,
		                            ApiDocumentModel model);

		Task<ActionResponse> Delete(Guid documentNode);

		Task<POCODocument> Get(Guid documentNode);

		Task<List<POCODocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCODocument> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);
		Task<List<POCODocument>> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>9d533a16f54d2b9c5f146c9133956265</Hash>
</Codenesium>*/