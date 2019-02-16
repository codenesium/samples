using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALCustomerCommunicationMapper
	{
		CustomerCommunication MapModelToEntity(
			int id,
			ApiCustomerCommunicationServerRequestModel model);

		ApiCustomerCommunicationServerResponseModel MapEntityToModel(
			CustomerCommunication item);

		List<ApiCustomerCommunicationServerResponseModel> MapEntityToModel(
			List<CustomerCommunication> items);
	}
}

/*<Codenesium>
    <Hash>2f8ebf5ebca4dae1bb3796e19d846bc4</Hash>
</Codenesium>*/