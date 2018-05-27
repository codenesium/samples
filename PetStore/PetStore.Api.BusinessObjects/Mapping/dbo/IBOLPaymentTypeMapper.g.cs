using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOLPaymentTypeMapper
	{
		DTOPaymentType MapModelToDTO(
			int id,
			ApiPaymentTypeRequestModel model);

		ApiPaymentTypeResponseModel MapDTOToModel(
			DTOPaymentType dtoPaymentType);

		List<ApiPaymentTypeResponseModel> MapDTOToModel(
			List<DTOPaymentType> dtos);
	}
}

/*<Codenesium>
    <Hash>9f27399a341f8c0105a2927be2dfd636</Hash>
</Codenesium>*/