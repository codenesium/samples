using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLCustomerCommunicationMapper
	{
		BOCustomerCommunication MapModelToBO(
			int id,
			ApiCustomerCommunicationServerRequestModel model);

		ApiCustomerCommunicationServerResponseModel MapBOToModel(
			BOCustomerCommunication boCustomerCommunication);

		List<ApiCustomerCommunicationServerResponseModel> MapBOToModel(
			List<BOCustomerCommunication> items);
	}
}

/*<Codenesium>
    <Hash>859c9123072e3bdc70df941ace4a9a09</Hash>
</Codenesium>*/