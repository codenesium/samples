using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>899f1263e19fe03761451f8030ae5b5c</Hash>
</Codenesium>*/