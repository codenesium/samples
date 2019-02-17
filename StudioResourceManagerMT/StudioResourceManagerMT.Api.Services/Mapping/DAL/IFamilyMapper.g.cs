using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>0ada70b1e051c57ef2e34c19f449bf74</Hash>
</Codenesium>*/