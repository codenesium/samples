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
			List<BOEmployeeDepartmentHistory> bos);
	}
}

/*<Codenesium>
    <Hash>cd781cd20248ee9042d018798cf079e3</Hash>
</Codenesium>*/