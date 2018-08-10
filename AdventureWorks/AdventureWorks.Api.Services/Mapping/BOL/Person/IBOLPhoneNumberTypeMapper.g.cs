using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPhoneNumberTypeMapper
	{
		BOPhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel model);

		ApiPhoneNumberTypeResponseModel MapBOToModel(
			BOPhoneNumberType boPhoneNumberType);

		List<ApiPhoneNumberTypeResponseModel> MapBOToModel(
			List<BOPhoneNumberType> items);
	}
}

/*<Codenesium>
    <Hash>8974fdef53b76f2478ac0748f2e4a1c1</Hash>
</Codenesium>*/