using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public interface IBOLPaymentTypeMapper
	{
		BOPaymentType MapModelToBO(
			int id,
			ApiPaymentTypeRequestModel model);

		ApiPaymentTypeResponseModel MapBOToModel(
			BOPaymentType boPaymentType);

		List<ApiPaymentTypeResponseModel> MapBOToModel(
			List<BOPaymentType> bos);
	}
}

/*<Codenesium>
    <Hash>53ed6bf9019e319feb1a793f08a07f6b</Hash>
</Codenesium>*/