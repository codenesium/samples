using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALPaymentTypeMapper
	{
		PaymentType MapModelToEntity(
			int id,
			ApiPaymentTypeServerRequestModel model);

		ApiPaymentTypeServerResponseModel MapEntityToModel(
			PaymentType item);

		List<ApiPaymentTypeServerResponseModel> MapEntityToModel(
			List<PaymentType> items);
	}
}

/*<Codenesium>
    <Hash>fea4f3bf23379987dd72329724ff8dec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/