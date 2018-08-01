using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>89684257930389a4b0d1afc6093f4b77</Hash>
</Codenesium>*/