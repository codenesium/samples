using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>0f7f2cd7077637fdd2a7162e7eda6761</Hash>
</Codenesium>*/