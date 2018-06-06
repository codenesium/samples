using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLShiftMapper
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
    <Hash>23e10ce770234e5b8ab28da45411c030</Hash>
</Codenesium>*/