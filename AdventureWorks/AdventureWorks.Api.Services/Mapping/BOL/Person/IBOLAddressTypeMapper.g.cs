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
			List<BOAddressType> bos);
	}
}

/*<Codenesium>
    <Hash>3404713dbfe4e5077c58f7c8894b3c0a</Hash>
</Codenesium>*/