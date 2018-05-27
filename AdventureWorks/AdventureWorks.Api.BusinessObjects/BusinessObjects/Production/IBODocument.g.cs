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
		Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model);

		Task<ActionResponse> Update(Guid documentNode,
		                            ApiDocumentRequestModel model);

		Task<ActionResponse> Delete(Guid documentNode);

		Task<ApiDocumentResponseModel> Get(Guid documentNode);

		Task<List<ApiDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiDocumentResponseModel> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);
		Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>7b317056498833f3af24e25bbb6367f9</Hash>
</Codenesium>*/