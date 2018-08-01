using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>edc05563c698c47e237b81415c2bae7f</Hash>
</Codenesium>*/