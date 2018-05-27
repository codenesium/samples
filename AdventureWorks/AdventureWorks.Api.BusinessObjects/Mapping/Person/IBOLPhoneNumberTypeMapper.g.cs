using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPhoneNumberTypeMapper
	{
		DTOPhoneNumberType MapModelToDTO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model);

		ApiPhoneNumberTypeResponseModel MapDTOToModel(
			DTOPhoneNumberType dtoPhoneNumberType);

		List<ApiPhoneNumberTypeResponseModel> MapDTOToModel(
			List<DTOPhoneNumberType> dtos);
	}
}

/*<Codenesium>
    <Hash>e98ce1e0496703bbc797555d87bb3b1c</Hash>
</Codenesium>*/