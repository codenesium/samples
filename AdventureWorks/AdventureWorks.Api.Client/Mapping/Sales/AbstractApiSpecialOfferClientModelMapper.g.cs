using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiSpecialOfferModelMapper
	{
		public virtual ApiSpecialOfferClientResponseModel MapClientRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferClientRequestModel request)
		{
			var response = new ApiSpecialOfferClientResponseModel();
			response.SetProperties(specialOfferID,
			                       request.Category,
			                       request.Description,
			                       request.DiscountPct,
			                       request.EndDate,
			                       request.MaxQty,
			                       request.MinQty,
			                       request.ModifiedDate,
			                       request.Rowguid,
			                       request.StartDate,
			                       request.Type);
			return response;
		}

		public virtual ApiSpecialOfferClientRequestModel MapClientResponseToRequest(
			ApiSpecialOfferClientResponseModel response)
		{
			var request = new ApiSpecialOfferClientRequestModel();
			request.SetProperties(
				response.Category,
				response.Description,
				response.DiscountPct,
				response.EndDate,
				response.MaxQty,
				response.MinQty,
				response.ModifiedDate,
				response.Rowguid,
				response.StartDate,
				response.Type);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>0939fe9a68d8f7848bec281f25d70e2a</Hash>
</Codenesium>*/