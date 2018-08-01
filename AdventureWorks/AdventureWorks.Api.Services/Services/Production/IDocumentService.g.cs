using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IDocumentService
	{
		Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model);

		Task<UpdateResponse<ApiDocumentResponseModel>> Update(Guid rowguid,
		                                                       ApiDocumentRequestModel model);

		Task<ActionResponse> Delete(Guid rowguid);

		Task<ApiDocumentResponseModel> Get(Guid rowguid);

		Task<List<ApiDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDocumentResponseModel>> ByFileNameRevision(string fileName, string revision);
	}
}

/*<Codenesium>
    <Hash>0e51ca2ab862c26b78e5eef4ca35889d</Hash>
</Codenesium>*/