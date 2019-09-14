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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/