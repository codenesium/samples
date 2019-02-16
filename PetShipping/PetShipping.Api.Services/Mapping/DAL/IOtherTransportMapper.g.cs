using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALOtherTransportMapper
	{
		OtherTransport MapModelToEntity(
			int id,
			ApiOtherTransportServerRequestModel model);

		ApiOtherTransportServerResponseModel MapEntityToModel(
			OtherTransport item);

		List<ApiOtherTransportServerResponseModel> MapEntityToModel(
			List<OtherTransport> items);
	}
}

/*<Codenesium>
    <Hash>f9085f6a08325c49eea1e289e8b2ce47</Hash>
</Codenesium>*/