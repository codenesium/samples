using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductInventoryModelMapper
	{
		public virtual ApiProductInventoryResponseModel MapRequestToResponse(
			int productID,
			ApiProductInventoryRequestModel request)
		{
			var response = new ApiProductInventoryResponseModel();
			response.SetProperties(productID,
			                       request.Bin,
			                       request.LocationID,
			                       request.ModifiedDate,
			                       request.Quantity,
			                       request.Rowguid,
			                       request.Shelf);
			return response;
		}

		public virtual ApiProductInventoryRequestModel MapResponseToRequest(
			ApiProductInventoryResponseModel response)
		{
			var request = new ApiProductInventoryRequestModel();
			request.SetProperties(
				response.Bin,
				response.LocationID,
				response.ModifiedDate,
				response.Quantity,
				response.Rowguid,
				response.Shelf);
			return request;
		}

		public JsonPatchDocument<ApiProductInventoryRequestModel> CreatePatch(ApiProductInventoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductInventoryRequestModel>();
			patch.Replace(x => x.Bin, model.Bin);
			patch.Replace(x => x.LocationID, model.LocationID);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Quantity, model.Quantity);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.Shelf, model.Shelf);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>15d2f1ee2fa429a68a64ff17d27d6820</Hash>
</Codenesium>*/