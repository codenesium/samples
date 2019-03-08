using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALBadgesMapper
	{
		Badges MapModelToEntity(
			int id,
			ApiBadgesServerRequestModel model);

		ApiBadgesServerResponseModel MapEntityToModel(
			Badges item);

		List<ApiBadgesServerResponseModel> MapEntityToModel(
			List<Badges> items);
	}
}

/*<Codenesium>
    <Hash>b4770cbbb01b2e7ccf51b08489afcd42</Hash>
</Codenesium>*/