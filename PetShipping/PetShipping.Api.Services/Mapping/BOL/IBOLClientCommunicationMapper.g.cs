using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>023314755dae80f6ae14aa8e37fce2ce</Hash>
</Codenesium>*/