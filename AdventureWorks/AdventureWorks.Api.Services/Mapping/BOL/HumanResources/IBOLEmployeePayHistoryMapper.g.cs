using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLEmployeePayHistoryMapper
	{
		BOEmployeePayHistory MapModelToBO(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model);

		ApiEmployeePayHistoryResponseModel MapBOToModel(
			BOEmployeePayHistory boEmployeePayHistory);

		List<ApiEmployeePayHistoryResponseModel> MapBOToModel(
			List<BOEmployeePayHistory> items);
	}
}

/*<Codenesium>
    <Hash>874e0f01ef806cfc75a8cf50d7eeae92</Hash>
</Codenesium>*/