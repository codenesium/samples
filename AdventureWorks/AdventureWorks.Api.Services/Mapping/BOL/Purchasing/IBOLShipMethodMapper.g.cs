using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLShipMethodMapper
        {
                BOShipMethod MapModelToBO(
                        int shipMethodID,
                        ApiShipMethodRequestModel model);

                ApiShipMethodResponseModel MapBOToModel(
                        BOShipMethod boShipMethod);

                List<ApiShipMethodResponseModel> MapBOToModel(
                        List<BOShipMethod> items);
        }
}

/*<Codenesium>
    <Hash>a5fc9aa82184f750e89e2683db896b8d</Hash>
</Codenesium>*/