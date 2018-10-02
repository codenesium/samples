using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLChainStatuMapper
	{
		BOChainStatu MapModelToBO(
			int id,
			ApiChainStatuRequestModel model);

		ApiChainStatuResponseModel MapBOToModel(
			BOChainStatu boChainStatu);

		List<ApiChainStatuResponseModel> MapBOToModel(
			List<BOChainStatu> items);
	}
}

/*<Codenesium>
    <Hash>a032a8698be9b38680dbac47ab444b4c</Hash>
</Codenesium>*/