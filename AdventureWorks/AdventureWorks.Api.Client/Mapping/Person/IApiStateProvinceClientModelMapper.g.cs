using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiStateProvinceModelMapper
	{
		ApiStateProvinceClientResponseModel MapClientRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceClientRequestModel request);

		ApiStateProvinceClientRequestModel MapClientResponseToRequest(
			ApiStateProvinceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0c76d7838a6e16a7880000626790ed7e</Hash>
</Codenesium>*/