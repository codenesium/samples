using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLScrapReasonMapper
        {
                BOScrapReason MapModelToBO(
                        short scrapReasonID,
                        ApiScrapReasonRequestModel model);

                ApiScrapReasonResponseModel MapBOToModel(
                        BOScrapReason boScrapReason);

                List<ApiScrapReasonResponseModel> MapBOToModel(
                        List<BOScrapReason> items);
        }
}

/*<Codenesium>
    <Hash>1140740761c38732d72abb489f4df682</Hash>
</Codenesium>*/