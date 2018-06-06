using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLIllustrationMapper
	{
		BOIllustration MapModelToBO(
			int illustrationID,
			ApiIllustrationRequestModel model);

		ApiIllustrationResponseModel MapBOToModel(
			BOIllustration boIllustration);

		List<ApiIllustrationResponseModel> MapBOToModel(
			List<BOIllustration> items);
	}
}

/*<Codenesium>
    <Hash>cdbf75cb6a3a2d625242440da6c3a0da</Hash>
</Codenesium>*/