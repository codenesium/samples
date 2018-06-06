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
			List<BOLocation> items);
	}
}

/*<Codenesium>
    <Hash>2856656d663d94641041a9f749f59a35</Hash>
</Codenesium>*/