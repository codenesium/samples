using AdventureWorksNS.Api.Contracts;
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
    <Hash>47d5bf5ecc9377603c6aeaa2f7550c5f</Hash>
</Codenesium>*/