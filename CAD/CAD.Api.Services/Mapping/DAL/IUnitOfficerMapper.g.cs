using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALUnitOfficerMapper
	{
		UnitOfficer MapModelToEntity(
			int id,
			ApiUnitOfficerServerRequestModel model);

		ApiUnitOfficerServerResponseModel MapEntityToModel(
			UnitOfficer item);

		List<ApiUnitOfficerServerResponseModel> MapEntityToModel(
			List<UnitOfficer> items);
	}
}

/*<Codenesium>
    <Hash>96c0365a4b65572fc5abcbe7cb3681b1</Hash>
</Codenesium>*/