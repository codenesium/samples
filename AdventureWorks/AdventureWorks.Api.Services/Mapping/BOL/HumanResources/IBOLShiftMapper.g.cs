using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>cfd10dfe44ca3a932718d1d145354d02</Hash>
</Codenesium>*/