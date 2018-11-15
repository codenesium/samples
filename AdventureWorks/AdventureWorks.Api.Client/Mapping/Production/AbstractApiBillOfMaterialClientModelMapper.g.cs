using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiBillOfMaterialModelMapper
	{
		public virtual ApiBillOfMaterialClientResponseModel MapClientRequestToResponse(
			int billOfMaterialsID,
			ApiBillOfMaterialClientRequestModel request)
		{
			var response = new ApiBillOfMaterialClientResponseModel();
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

		public virtual ApiBillOfMaterialClientRequestModel MapClientResponseToRequest(
			ApiBillOfMaterialClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>2441eedc2334011a0c26055945faeaab</Hash>
</Codenesium>*/