using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLPostHistoryTypesMapper
        {
                BOPostHistoryTypes MapModelToBO(
                        int id,
                        ApiPostHistoryTypesRequestModel model);

                ApiPostHistoryTypesResponseModel MapBOToModel(
                        BOPostHistoryTypes boPostHistoryTypes);

                List<ApiPostHistoryTypesResponseModel> MapBOToModel(
                        List<BOPostHistoryTypes> items);
        }
}

/*<Codenesium>
    <Hash>c8a491b33b911bb687ba393e12b12530</Hash>
</Codenesium>*/