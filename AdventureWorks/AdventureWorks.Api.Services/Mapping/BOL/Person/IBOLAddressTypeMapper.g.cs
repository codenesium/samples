using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLAddressTypeMapper
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
    <Hash>6d6d5bc79c0eb43b5d8c5c9c55bad185</Hash>
</Codenesium>*/