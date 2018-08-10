using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLBusinessEntityContactMapper
	{
		BOBusinessEntityContact MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model);

		ApiBusinessEntityContactResponseModel MapBOToModel(
			BOBusinessEntityContact boBusinessEntityContact);

		List<ApiBusinessEntityContactResponseModel> MapBOToModel(
			List<BOBusinessEntityContact> items);
	}
}

/*<Codenesium>
    <Hash>7e078cf383fb68933d428db4744aa01e</Hash>
</Codenesium>*/