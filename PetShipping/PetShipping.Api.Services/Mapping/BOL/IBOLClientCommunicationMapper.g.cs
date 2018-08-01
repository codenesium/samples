using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLClientCommunicationMapper
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
    <Hash>683d8bb2534f801cc67b027f4ef65359</Hash>
</Codenesium>*/