using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLEmployeeDepartmentHistoryMapper
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
    <Hash>7871b425462c03d711be948d0fa3f88a</Hash>
</Codenesium>*/