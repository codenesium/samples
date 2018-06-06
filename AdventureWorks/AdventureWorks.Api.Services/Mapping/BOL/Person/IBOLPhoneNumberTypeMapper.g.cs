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
			List<BOPhoneNumberType> items);
	}
}

/*<Codenesium>
    <Hash>29b2cb1661efe8257db406a371af194d</Hash>
</Codenesium>*/