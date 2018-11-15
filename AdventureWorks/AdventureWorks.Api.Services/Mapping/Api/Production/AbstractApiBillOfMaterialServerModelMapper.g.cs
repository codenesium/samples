using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiBillOfMaterialServerModelMapper
	{
		public virtual ApiBillOfMaterialServerResponseModel MapServerRequestToResponse(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel request)
		{
			var response = new ApiBillOfMaterialServerResponseModel();
			response.SetProperties(billOfMaterialsID,
			                       request.BOMLevel,
			                       request.ComponentID,
			                       request.EndDate,
			                       request.ModifiedDate,
			                       request.PerAssemblyQty,
			                       request.ProductAssemblyID,
			                       request.StartDate,
			                       request.UnitMeasureCode);
			return response;
		}

		public virtual ApiBillOfMaterialServerRequestModel MapServerResponseToRequest(
			ApiBillOfMaterialServerResponseModel response)
		{
			var request = new ApiBillOfMaterialServerRequestModel();
			request.SetProperties(
				response.BOMLevel,
				response.ComponentID,
				response.EndDate,
				response.ModifiedDate,
				response.PerAssemblyQty,
				response.ProductAssemblyID,
				response.StartDate,
				response.UnitMeasureCode);
			return request;
		}

		public virtual ApiBillOfMaterialClientRequestModel MapServerResponseToClientRequest(
			ApiBillOfMaterialServerResponseModel response)
		{
			var request = new ApiBillOfMaterialClientRequestModel();
			request.SetProperties(
				response.BOMLevel,
				response.ComponentID,
				response.EndDate,
				response.ModifiedDate,
				response.PerAssemblyQty,
				response.ProductAssemblyID,
				response.StartDate,
				response.UnitMeasureCode);
			return request;
		}

		public JsonPatchDocument<ApiBillOfMaterialServerRequestModel> CreatePatch(ApiBillOfMaterialServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBillOfMaterialServerRequestModel>();
			patch.Replace(x => x.BOMLevel, model.BOMLevel);
			patch.Replace(x => x.ComponentID, model.ComponentID);
			patch.Replace(x => x.EndDate, model.EndDate);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.PerAssemblyQty, model.PerAssemblyQty);
			patch.Replace(x => x.ProductAssemblyID, model.ProductAssemblyID);
			patch.Replace(x => x.StartDate, model.StartDate);
			patch.Replace(x => x.UnitMeasureCode, model.UnitMeasureCode);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c984b103b9d956e0dfebd830ea98e7d5</Hash>
</Codenesium>*/