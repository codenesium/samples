using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLPostTypesMapper
        {
                BOPostTypes MapModelToBO(
                        int id,
                        ApiPostTypesRequestModel model);

                ApiPostTypesResponseModel MapBOToModel(
                        BOPostTypes boPostTypes);

                List<ApiPostTypesResponseModel> MapBOToModel(
                        List<BOPostTypes> items);
        }
}

/*<Codenesium>
    <Hash>a675d7ce0d4e1ab80ca0382b0793b1bb</Hash>
</Codenesium>*/