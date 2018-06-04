using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesReasonMapper
	{
		BOSalesReason MapModelToBO(
			int salesReasonID,
			ApiSalesReasonRequestModel model);

		ApiSalesReasonResponseModel MapBOToModel(
			BOSalesReason boSalesReason);

		List<ApiSalesReasonResponseModel> MapBOToModel(
			List<BOSalesReason> bos);
	}
}

/*<Codenesium>
    <Hash>bdb3f4f088c3f01d51d17b1234a0431b</Hash>
</Codenesium>*/