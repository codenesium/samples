using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITicketService
	{
		Task<CreateResponse<ApiTicketServerResponseModel>> Create(
			ApiTicketServerRequestModel model);

		Task<UpdateResponse<ApiTicketServerResponseModel>> Update(int id,
		                                                           ApiTicketServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketServerResponseModel> Get(int id);

		Task<List<ApiTicketServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTicketServerResponseModel>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleTicketsServerResponseModel>> SaleTicketsByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fd1fb44e88948a62831e7774d3518b86</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/