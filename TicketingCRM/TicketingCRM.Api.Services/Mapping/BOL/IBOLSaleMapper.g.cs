using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLSaleMapper
        {
                BOSale MapModelToBO(
                        int id,
                        ApiSaleRequestModel model);

                ApiSaleResponseModel MapBOToModel(
                        BOSale boSale);

                List<ApiSaleResponseModel> MapBOToModel(
                        List<BOSale> items);
        }
}

/*<Codenesium>
    <Hash>b881553f0473da3f2a742fbfb92908cc</Hash>
</Codenesium>*/