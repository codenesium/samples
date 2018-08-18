using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiDocumentModelMapper
	{
		public virtual ApiDocumentResponseModel MapRequestToResponse(
			Guid rowguid,
			ApiDocumentRequestModel request)
		{
			var response = new ApiDocumentResponseModel();
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

		public virtual ApiDocumentRequestModel MapResponseToRequest(
			ApiDocumentResponseModel response)
		{
			var request = new ApiDocumentRequestModel();
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

		public JsonPatchDocument<ApiDocumentRequestModel> CreatePatch(ApiDocumentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDocumentRequestModel>();
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
    <Hash>e746d2c1f63cce83d53c7762adcf2329</Hash>
</Codenesium>*/