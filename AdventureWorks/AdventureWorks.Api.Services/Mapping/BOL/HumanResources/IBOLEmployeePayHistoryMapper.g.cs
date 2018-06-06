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
			List<BOEmployeePayHistory> items);
	}
}

/*<Codenesium>
    <Hash>996c44f4b8b2067a0aecae7d019b096e</Hash>
</Codenesium>*/