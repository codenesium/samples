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
    <Hash>083dee95b6e73fec128911bdac64362e</Hash>
</Codenesium>*/