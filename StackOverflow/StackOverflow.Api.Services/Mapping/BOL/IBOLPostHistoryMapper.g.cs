using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLPostHistoryMapper
        {
                BOPostHistory MapModelToBO(
                        int id,
                        ApiPostHistoryRequestModel model);

                ApiPostHistoryResponseModel MapBOToModel(
                        BOPostHistory boPostHistory);

                List<ApiPostHistoryResponseModel> MapBOToModel(
                        List<BOPostHistory> items);
        }
}

/*<Codenesium>
    <Hash>edba856bcf599545f9e2fe4687a8e64d</Hash>
</Codenesium>*/