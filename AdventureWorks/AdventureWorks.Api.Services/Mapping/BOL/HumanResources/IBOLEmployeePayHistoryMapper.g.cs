using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLEmployeePayHistoryMapper
	{
		BOEmployeePayHistory MapModelToBO(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model);

		ApiEmployeePayHistoryResponseModel MapBOToModel(
			BOEmployeePayHistory boEmployeePayHistory);

		List<ApiEmployeePayHistoryResponseModel> MapBOToModel(
			List<BOEmployeePayHistory> bos);
	}
}

/*<Codenesium>
    <Hash>74862158fa51e5b500e752739208dece</Hash>
</Codenesium>*/