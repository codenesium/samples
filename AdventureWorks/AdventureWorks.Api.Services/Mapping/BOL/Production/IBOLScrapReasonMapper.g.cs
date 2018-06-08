using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>1af0107cc0ceb563a4b83501af54d365</Hash>
</Codenesium>*/