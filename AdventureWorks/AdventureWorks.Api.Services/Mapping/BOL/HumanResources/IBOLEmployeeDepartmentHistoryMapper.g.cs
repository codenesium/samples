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
    <Hash>4bba7cb9e8f95d0eacd02a55c6aaa22f</Hash>
</Codenesium>*/