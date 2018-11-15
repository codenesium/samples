using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductDescriptionModelMapper
	{
		ApiProductDescriptionClientResponseModel MapClientRequestToResponse(
			int productDescriptionID,
			ApiProductDescriptionClientRequestModel request);

		ApiProductDescriptionClientRequestModel MapClientResponseToRequest(
			ApiProductDescriptionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7205a58a7a538d23d9ef32a721086e5a</Hash>
</Codenesium>*/