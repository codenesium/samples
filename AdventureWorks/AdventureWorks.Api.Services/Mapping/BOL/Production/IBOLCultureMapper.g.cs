using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCultureMapper
	{
		BOCulture MapModelToBO(
			string cultureID,
			ApiCultureRequestModel model);

		ApiCultureResponseModel MapBOToModel(
			BOCulture boCulture);

		List<ApiCultureResponseModel> MapBOToModel(
			List<BOCulture> items);
	}
}

/*<Codenesium>
    <Hash>c5468f3987eeabbef59c9f3c3af5cba9</Hash>
</Codenesium>*/