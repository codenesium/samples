using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>747bbc33886734e4aae0e3d527ae4457</Hash>
</Codenesium>*/