using PointOfSaleNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Client
{
	public partial interface IApiSaleModelMapper
	{
		ApiSaleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleClientRequestModel request);

		ApiSaleClientRequestModel MapClientResponseToRequest(
			ApiSaleClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>83849e20b8575c753829253a3425fd9d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/