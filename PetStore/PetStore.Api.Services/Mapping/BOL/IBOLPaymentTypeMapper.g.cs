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
			List<BOPaymentType> items);
	}
}

/*<Codenesium>
    <Hash>0531a9f43335d51735b056bdd5fae2d7</Hash>
</Codenesium>*/