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
    <Hash>e757ea6315414b12a9d17857670acf47</Hash>
</Codenesium>*/