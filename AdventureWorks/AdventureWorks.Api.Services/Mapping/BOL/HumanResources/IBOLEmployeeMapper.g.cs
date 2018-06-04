using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLEmployeeMapper
	{
		BOEmployee MapModelToBO(
			int businessEntityID,
			ApiEmployeeRequestModel model);

		ApiEmployeeResponseModel MapBOToModel(
			BOEmployee boEmployee);

		List<ApiEmployeeResponseModel> MapBOToModel(
			List<BOEmployee> bos);
	}
}

/*<Codenesium>
    <Hash>acde3f7c6ffdbe4168dc062b8b6d3252</Hash>
</Codenesium>*/