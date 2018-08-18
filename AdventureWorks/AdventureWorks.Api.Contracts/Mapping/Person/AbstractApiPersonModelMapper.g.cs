using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiPersonModelMapper
	{
		public virtual ApiPersonResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonRequestModel request)
		{
			var response = new ApiPersonResponseModel();
			response.SetProperties(businessEntityID,
			                       request.AdditionalContactInfo,
			                       request.Demographic,
			                       request.EmailPromotion,
			                       request.FirstName,
			                       request.LastName,
			                       request.MiddleName,
			                       request.ModifiedDate,
			                       request.NameStyle,
			                       request.PersonType,
			                       request.Rowguid,
			                       request.Suffix,
			                       request.Title);
			return response;
		}

		public virtual ApiPersonRequestModel MapResponseToRequest(
			ApiPersonResponseModel response)
		{
			var request = new ApiPersonRequestModel();
			request.SetProperties(
				response.AdditionalContactInfo,
				response.Demographic,
				response.EmailPromotion,
				response.FirstName,
				response.LastName,
				response.MiddleName,
				response.ModifiedDate,
				response.NameStyle,
				response.PersonType,
				response.Rowguid,
				response.Suffix,
				response.Title);
			return request;
		}

		public JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonRequestModel>();
			patch.Replace(x => x.AdditionalContactInfo, model.AdditionalContactInfo);
			patch.Replace(x => x.Demographic, model.Demographic);
			patch.Replace(x => x.EmailPromotion, model.EmailPromotion);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.MiddleName, model.MiddleName);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.NameStyle, model.NameStyle);
			patch.Replace(x => x.PersonType, model.PersonType);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.Suffix, model.Suffix);
			patch.Replace(x => x.Title, model.Title);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>19b71a1a4f27ca283ec474835da9ac6d</Hash>
</Codenesium>*/