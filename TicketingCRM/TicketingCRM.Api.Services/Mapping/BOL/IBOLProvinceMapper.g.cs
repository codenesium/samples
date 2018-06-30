using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLProvinceMapper
        {
                BOProvince MapModelToBO(
                        int id,
                        ApiProvinceRequestModel model);

                ApiProvinceResponseModel MapBOToModel(
                        BOProvince boProvince);

                List<ApiProvinceResponseModel> MapBOToModel(
                        List<BOProvince> items);
        }
}

/*<Codenesium>
    <Hash>98e46b3a35483c29271661fba5753251</Hash>
</Codenesium>*/