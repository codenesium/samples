using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiPersonModelMapper
	{
		public virtual ApiPersonClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiPersonClientRequestModel request)
		{
			var response = new ApiPersonClientResponseModel();
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

		public virtual ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
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
	}
}

/*<Codenesium>
    <Hash>097e3a51a9f72e2e08d7780e90a886df</Hash>
</Codenesium>*/