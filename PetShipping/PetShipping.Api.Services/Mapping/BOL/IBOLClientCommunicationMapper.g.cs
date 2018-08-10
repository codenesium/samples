using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLClientCommunicationMapper
	{
		BOClientCommunication MapModelToBO(
			int id,
			ApiClientCommunicationRequestModel model);

		ApiClientCommunicationResponseModel MapBOToModel(
			BOClientCommunication boClientCommunication);

		List<ApiClientCommunicationResponseModel> MapBOToModel(
			List<BOClientCommunication> items);
	}
}

/*<Codenesium>
    <Hash>5c84f80b2a2c446c5048696e70b743bf</Hash>
</Codenesium>*/