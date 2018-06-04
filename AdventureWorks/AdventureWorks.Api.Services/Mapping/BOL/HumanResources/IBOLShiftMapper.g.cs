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
			List<BOShift> bos);
	}
}

/*<Codenesium>
    <Hash>12c38db8161a876c15e76922e6dec664</Hash>
</Codenesium>*/