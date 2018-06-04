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
			List<BOClientCommunication> bos);
	}
}

/*<Codenesium>
    <Hash>1a34465478990ba4c0064fcab2971b1a</Hash>
</Codenesium>*/