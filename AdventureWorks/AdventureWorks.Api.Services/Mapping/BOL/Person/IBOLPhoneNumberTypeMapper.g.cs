using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPhoneNumberTypeMapper
	{
		BOPhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model);

		ApiPhoneNumberTypeResponseModel MapBOToModel(
			BOPhoneNumberType boPhoneNumberType);

		List<ApiPhoneNumberTypeResponseModel> MapBOToModel(
			List<BOPhoneNumberType> bos);
	}
}

/*<Codenesium>
    <Hash>dc9e263607a542d8c98913d2f9be87b2</Hash>
</Codenesium>*/