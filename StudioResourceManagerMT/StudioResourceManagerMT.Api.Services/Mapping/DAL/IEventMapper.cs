using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventMapper
	{
		Event MapModelToEntity(
			int id,
			ApiEventServerRequestModel model);

		ApiEventServerResponseModel MapEntityToModel(
			Event item);

		List<ApiEventServerResponseModel> MapEntityToModel(
			List<Event> items);
	}
}

/*<Codenesium>
    <Hash>0a640edc6f26d3b695e7db3350ee4b38</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/