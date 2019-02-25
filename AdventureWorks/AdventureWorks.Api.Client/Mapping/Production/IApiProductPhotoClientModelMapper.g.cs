using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductPhotoModelMapper
	{
		ApiProductPhotoClientResponseModel MapClientRequestToResponse(
			int productPhotoID,
			ApiProductPhotoClientRequestModel request);

		ApiProductPhotoClientRequestModel MapClientResponseToRequest(
			ApiProductPhotoClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>72be0e79c093b97aa43ce9fc20ea4b5d</Hash>
</Codenesium>*/