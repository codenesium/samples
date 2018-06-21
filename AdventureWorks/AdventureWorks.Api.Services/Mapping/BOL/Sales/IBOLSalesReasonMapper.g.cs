using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesReasonMapper
        {
                BOSalesReason MapModelToBO(
                        int salesReasonID,
                        ApiSalesReasonRequestModel model);

                ApiSalesReasonResponseModel MapBOToModel(
                        BOSalesReason boSalesReason);

                List<ApiSalesReasonResponseModel> MapBOToModel(
                        List<BOSalesReason> items);
        }
}

/*<Codenesium>
    <Hash>d9362ec6da730c225857b409bce93f5f</Hash>
</Codenesium>*/