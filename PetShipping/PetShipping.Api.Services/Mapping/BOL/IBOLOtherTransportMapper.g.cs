using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLOtherTransportMapper
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
    <Hash>82da6cc555a2fe8a8bb9b8ccaa2408e2</Hash>
</Codenesium>*/