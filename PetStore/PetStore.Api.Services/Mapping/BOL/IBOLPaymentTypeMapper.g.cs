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
			ApiPaymentTypeServerRequestModel model);

		ApiPaymentTypeServerResponseModel MapBOToModel(
			BOPaymentType boPaymentType);

		List<ApiPaymentTypeServerResponseModel> MapBOToModel(
			List<BOPaymentType> items);
	}
}

/*<Codenesium>
    <Hash>6d6c292a6115da4238f84c3fad742138</Hash>
</Codenesium>*/