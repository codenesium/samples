using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPersonCreditCardMapper
	{
		DTOPersonCreditCard MapModelToDTO(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model);

		ApiPersonCreditCardResponseModel MapDTOToModel(
			DTOPersonCreditCard dtoPersonCreditCard);

		List<ApiPersonCreditCardResponseModel> MapDTOToModel(
			List<DTOPersonCreditCard> dtos);
	}
}

/*<Codenesium>
    <Hash>7136397a075cb9e98d80829604a58efa</Hash>
</Codenesium>*/