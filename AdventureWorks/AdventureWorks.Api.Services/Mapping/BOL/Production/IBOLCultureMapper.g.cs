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
			List<BOCulture> bos);
	}
}

/*<Codenesium>
    <Hash>3460d1f93a6d253c22bae412a1a12d38</Hash>
</Codenesium>*/