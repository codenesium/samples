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
    <Hash>ee308ee56fd9fa113f4c2bdc6748fe16</Hash>
</Codenesium>*/