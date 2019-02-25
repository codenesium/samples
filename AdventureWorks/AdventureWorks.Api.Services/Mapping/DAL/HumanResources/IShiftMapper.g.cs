using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShiftMapper
	{
		Shift MapModelToEntity(
			int shiftID,
			ApiShiftServerRequestModel model);

		ApiShiftServerResponseModel MapEntityToModel(
			Shift item);

		List<ApiShiftServerResponseModel> MapEntityToModel(
			List<Shift> items);
	}
}

/*<Codenesium>
    <Hash>7f4b4b292bae5132f9bf88845e13a3bf</Hash>
</Codenesium>*/