using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLBusinessEntityContactMapper
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
    <Hash>7acff0717c35fa89712536663c0be82c</Hash>
</Codenesium>*/