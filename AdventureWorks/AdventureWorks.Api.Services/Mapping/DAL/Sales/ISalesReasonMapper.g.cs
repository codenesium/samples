using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesReasonMapper
	{
		SalesReason MapModelToBO(
			int salesReasonID,
			ApiSalesReasonServerRequestModel model);

		ApiSalesReasonServerResponseModel MapBOToModel(
			SalesReason item);

		List<ApiSalesReasonServerResponseModel> MapBOToModel(
			List<SalesReason> items);
	}
}

/*<Codenesium>
    <Hash>748cc703f1303e51cdd1470805ceae7c</Hash>
</Codenesium>*/