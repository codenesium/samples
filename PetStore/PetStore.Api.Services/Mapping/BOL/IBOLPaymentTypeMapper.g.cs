using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IBOLPaymentTypeMapper
	{
		BOPaymentType MapModelToBO(
			int id,
			ApiPaymentTypeRequestModel model);

		ApiPaymentTypeResponseModel MapBOToModel(
			BOPaymentType boPaymentType);

		List<ApiPaymentTypeResponseModel> MapBOToModel(
			List<BOPaymentType> items);
	}
}

/*<Codenesium>
    <Hash>61845cdd5ee09125df42a0761ee6c78a</Hash>
</Codenesium>*/