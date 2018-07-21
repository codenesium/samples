using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTicketModelMapper
        {
                ApiTicketResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketRequestModel request);

                ApiTicketRequestModel MapResponseToRequest(
                        ApiTicketResponseModel response);

                JsonPatchDocument<ApiTicketRequestModel> CreatePatch(ApiTicketRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9662a31cf306bb404fb984c3f9c82393</Hash>
</Codenesium>*/