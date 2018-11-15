using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLShiftMapper
	{
		BOShift MapModelToBO(
			int shiftID,
			ApiShiftServerRequestModel model);

		ApiShiftServerResponseModel MapBOToModel(
			BOShift boShift);

		List<ApiShiftServerResponseModel> MapBOToModel(
			List<BOShift> items);
	}
}

/*<Codenesium>
    <Hash>143dd7dae4045e94f859c9b6ca31d472</Hash>
</Codenesium>*/