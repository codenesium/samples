using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiBillOfMaterialModelMapper
	{
		ApiBillOfMaterialClientResponseModel MapClientRequestToResponse(
			int billOfMaterialsID,
			ApiBillOfMaterialClientRequestModel request);

		ApiBillOfMaterialClientRequestModel MapClientResponseToRequest(
			ApiBillOfMaterialClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>31cb51076898161250da8a55b12cd39b</Hash>
</Codenesium>*/