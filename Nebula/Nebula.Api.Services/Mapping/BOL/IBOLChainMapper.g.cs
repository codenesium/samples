using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IBOLChainMapper
	{
		BOChain MapModelToBO(
			int id,
			ApiChainRequestModel model);

		ApiChainResponseModel MapBOToModel(
			BOChain boChain);

		List<ApiChainResponseModel> MapBOToModel(
			List<BOChain> items);
	}
}

/*<Codenesium>
    <Hash>c7dea57c41ac9559a9c1b83ba50a40b0</Hash>
</Codenesium>*/