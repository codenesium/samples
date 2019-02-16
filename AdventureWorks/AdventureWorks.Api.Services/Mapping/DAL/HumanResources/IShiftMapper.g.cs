using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShiftMapper
	{
		Shift MapModelToBO(
			int shiftID,
			ApiShiftServerRequestModel model);

		ApiShiftServerResponseModel MapBOToModel(
			Shift item);

		List<ApiShiftServerResponseModel> MapBOToModel(
			List<Shift> items);
	}
}

/*<Codenesium>
    <Hash>d80ee9da4997dd9ced053f41eda93c7c</Hash>
</Codenesium>*/