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
			List<BOChain> bos);
	}
}

/*<Codenesium>
    <Hash>9519245574c1e8659ea8d480cacb32f0</Hash>
</Codenesium>*/