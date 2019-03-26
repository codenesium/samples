using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiDocumentModelMapper
	{
		public virtual ApiDocumentClientResponseModel MapClientRequestToResponse(
			Guid rowguid,
			ApiDocumentClientRequestModel request)
		{
			var response = new ApiDocumentClientResponseModel();
			response.SetProperties(rowguid,
			                       request.ChangeNumber,
			                       request.Document1,
			                       request.DocumentLevel,
			                       request.DocumentSummary,
			                       request.FileExtension,
			                       request.FileName,
			                       request.FolderFlag,
			                       request.ModifiedDate,
			                       request.Owner,
			                       request.Revision,
			                       request.Status,
			                       request.Title);
			return response;
		}

		public virtual ApiDocumentClientRequestModel MapClientResponseToRequest(
			ApiDocumentClientResponseModel response)
		{
			var request = new ApiDocumentClientRequestModel();
			request.SetProperties(
				response.ChangeNumber,
				response.Document1,
				response.DocumentLevel,
				response.DocumentSummary,
				response.FileExtension,
				response.FileName,
				response.FolderFlag,
				response.ModifiedDate,
				response.Owner,
				response.Revision,
				response.Status,
				response.Title);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>908d7b5315f0fa6be6e432798af6d90b</Hash>
</Codenesium>*/