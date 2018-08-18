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
    <Hash>a67e081b814e1575015ce91b4ed56ab6</Hash>
</Codenesium>*/