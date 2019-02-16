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
			                       request.StartDate);
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
				response.StartDate);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2f330f2467a98e74d7505b256c4fdcee</Hash>
</Codenesium>*/