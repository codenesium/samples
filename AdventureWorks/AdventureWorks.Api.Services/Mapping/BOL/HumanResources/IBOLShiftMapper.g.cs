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
			ApiShiftRequestModel model);

		ApiShiftResponseModel MapBOToModel(
			BOShift boShift);

		List<ApiShiftResponseModel> MapBOToModel(
			List<BOShift> items);
	}
}

/*<Codenesium>
    <Hash>59defaa714f9f21c4e1d3def20156b6c</Hash>
</Codenesium>*/