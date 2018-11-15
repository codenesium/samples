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
			ApiClientCommunicationServerRequestModel model);

		ApiClientCommunicationServerResponseModel MapBOToModel(
			BOClientCommunication boClientCommunication);

		List<ApiClientCommunicationServerResponseModel> MapBOToModel(
			List<BOClientCommunication> items);
	}
}

/*<Codenesium>
    <Hash>047561eb43f984906699b4afb1f30398</Hash>
</Codenesium>*/