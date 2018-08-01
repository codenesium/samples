using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2cfadf993d72d9b42915819e3b0ed254</Hash>
</Codenesium>*/