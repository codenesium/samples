using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALFamilyMapper
	{
		Family MapModelToEntity(
			int id,
			ApiFamilyServerRequestModel model);

		ApiFamilyServerResponseModel MapEntityToModel(
			Family item);

		List<ApiFamilyServerResponseModel> MapEntityToModel(
			List<Family> items);
	}
}

/*<Codenesium>
    <Hash>3a04acd0b847350636a8ef4d227312e0</Hash>
</Codenesium>*/