using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLVenueMapper
        {
                BOVenue MapModelToBO(
                        int id,
                        ApiVenueRequestModel model);

                ApiVenueResponseModel MapBOToModel(
                        BOVenue boVenue);

                List<ApiVenueResponseModel> MapBOToModel(
                        List<BOVenue> items);
        }
}

/*<Codenesium>
    <Hash>72e4f96c823e2835cc378f6e0725c988</Hash>
</Codenesium>*/