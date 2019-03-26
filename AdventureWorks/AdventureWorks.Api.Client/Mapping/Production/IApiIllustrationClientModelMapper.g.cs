using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiIllustrationModelMapper
	{
		ApiIllustrationClientResponseModel MapClientRequestToResponse(
			int illustrationID,
			ApiIllustrationClientRequestModel request);

		ApiIllustrationClientRequestModel MapClientResponseToRequest(
			ApiIllustrationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d821fce52ae54558f70ea6e846b5ab21</Hash>
</Codenesium>*/