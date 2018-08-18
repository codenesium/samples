using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLOtherTransportMapper
	{
		BOOtherTransport MapModelToBO(
			int id,
			ApiOtherTransportRequestModel model);

		ApiOtherTransportResponseModel MapBOToModel(
			BOOtherTransport boOtherTransport);

		List<ApiOtherTransportResponseModel> MapBOToModel(
			List<BOOtherTransport> items);
	}
}

/*<Codenesium>
    <Hash>f5d26f0b583d9d9e5e232605ef919ebe</Hash>
</Codenesium>*/