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
			List<BOSalesReason> items);
	}
}

/*<Codenesium>
    <Hash>fa3ae43a391ee67548e2463d21cdf20c</Hash>
</Codenesium>*/