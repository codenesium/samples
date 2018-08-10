using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLEmployeeDepartmentHistoryMapper
	{
		BOEmployeeDepartmentHistory MapModelToBO(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model);

		ApiEmployeeDepartmentHistoryResponseModel MapBOToModel(
			BOEmployeeDepartmentHistory boEmployeeDepartmentHistory);

		List<ApiEmployeeDepartmentHistoryResponseModel> MapBOToModel(
			List<BOEmployeeDepartmentHistory> items);
	}
}

/*<Codenesium>
    <Hash>be98e0f10efdce8525e07eef0a042b00</Hash>
</Codenesium>*/