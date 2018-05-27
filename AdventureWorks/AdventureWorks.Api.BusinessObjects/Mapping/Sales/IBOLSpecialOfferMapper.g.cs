using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSpecialOfferMapper
	{
		DTOSpecialOffer MapModelToDTO(
			int specialOfferID,
			ApiSpecialOfferRequestModel model);

		ApiSpecialOfferResponseModel MapDTOToModel(
			DTOSpecialOffer dtoSpecialOffer);

		List<ApiSpecialOfferResponseModel> MapDTOToModel(
			List<DTOSpecialOffer> dtos);
	}
}

/*<Codenesium>
    <Hash>eae8c129e1d2e15550baf58f24832ff7</Hash>
</Codenesium>*/