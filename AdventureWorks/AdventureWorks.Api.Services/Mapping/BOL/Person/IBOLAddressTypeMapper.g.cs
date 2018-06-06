using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLAddressTypeMapper
	{
		BOAddressType MapModelToBO(
			int addressTypeID,
			ApiAddressTypeRequestModel model);

		ApiAddressTypeResponseModel MapBOToModel(
			BOAddressType boAddressType);

		List<ApiAddressTypeResponseModel> MapBOToModel(
			List<BOAddressType> items);
	}
}

/*<Codenesium>
    <Hash>b01dd35fa61f809bb5379e05b1aace0c</Hash>
</Codenesium>*/