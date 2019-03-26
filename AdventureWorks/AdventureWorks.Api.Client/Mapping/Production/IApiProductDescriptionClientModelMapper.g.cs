using AdventureWorksNS.Api.Contracts;
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
    <Hash>058ab01d67aa8f0687b69f0d9101bd72</Hash>
</Codenesium>*/