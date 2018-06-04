using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLLocationMapper
	{
		BOLocation MapModelToBO(
			short locationID,
			ApiLocationRequestModel model);

		ApiLocationResponseModel MapBOToModel(
			BOLocation boLocation);

		List<ApiLocationResponseModel> MapBOToModel(
			List<BOLocation> bos);
	}
}

/*<Codenesium>
    <Hash>6805729d6fdae1df71d54e8bac1ff0b3</Hash>
</Codenesium>*/