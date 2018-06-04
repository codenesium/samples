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
			List<BOIllustration> bos);
	}
}

/*<Codenesium>
    <Hash>3f5ccf711bfd9c183a30d4d4cb9984ff</Hash>
</Codenesium>*/