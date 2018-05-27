using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSpecialOfferProductMapper
	{
		DTOSpecialOfferProduct MapModelToDTO(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model);

		ApiSpecialOfferProductResponseModel MapDTOToModel(
			DTOSpecialOfferProduct dtoSpecialOfferProduct);

		List<ApiSpecialOfferProductResponseModel> MapDTOToModel(
			List<DTOSpecialOfferProduct> dtos);
	}
}

/*<Codenesium>
    <Hash>c123fde911322047750b15a20dd250d9</Hash>
</Codenesium>*/