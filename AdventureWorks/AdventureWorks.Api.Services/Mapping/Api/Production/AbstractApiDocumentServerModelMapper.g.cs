using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiDocumentServerModelMapper
	{
		public virtual ApiDocumentServerResponseModel MapServerRequestToResponse(
			Guid rowguid,
			ApiDocumentServerRequestModel request)
		{
			var response = new ApiDocumentServerResponseModel();
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

		public virtual ApiDocumentServerRequestModel MapServerResponseToRequest(
			ApiDocumentServerResponseModel response)
		{
			var request = new ApiDocumentServerRequestModel();
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

		public virtual ApiDocumentClientRequestModel MapServerResponseToClientRequest(
			ApiDocumentServerResponseModel response)
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

		public JsonPatchDocument<ApiDocumentServerRequestModel> CreatePatch(ApiDocumentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDocumentServerRequestModel>();
			patch.Replace(x => x.ChangeNumber, model.ChangeNumber);
			patch.Replace(x => x.Document1, model.Document1);
			patch.Replace(x => x.DocumentLevel, model.DocumentLevel);
			patch.Replace(x => x.DocumentSummary, model.DocumentSummary);
			patch.Replace(x => x.FileExtension, model.FileExtension);
			patch.Replace(x => x.FileName, model.FileName);
			patch.Replace(x => x.FolderFlag, model.FolderFlag);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Owner, model.Owner);
			patch.Replace(x => x.Revision, model.Revision);
			patch.Replace(x => x.Status, model.Status);
			patch.Replace(x => x.Title, model.Title);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>870d4897a40b0e6f6d0965c14e82df8f</Hash>
</Codenesium>*/