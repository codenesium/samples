using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCreditCardMapper
	{
		DTOCreditCard MapModelToDTO(
			int creditCardID,
			ApiCreditCardRequestModel model);

		ApiCreditCardResponseModel MapDTOToModel(
			DTOCreditCard dtoCreditCard);

		List<ApiCreditCardResponseModel> MapDTOToModel(
			List<DTOCreditCard> dtos);
	}
}

/*<Codenesium>
    <Hash>86f5d64bcfbe3bad91e3a05ee3f75f17</Hash>
</Codenesium>*/