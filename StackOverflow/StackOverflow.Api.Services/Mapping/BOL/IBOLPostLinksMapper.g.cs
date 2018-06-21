using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLPostLinksMapper
        {
                BOPostLinks MapModelToBO(
                        int id,
                        ApiPostLinksRequestModel model);

                ApiPostLinksResponseModel MapBOToModel(
                        BOPostLinks boPostLinks);

                List<ApiPostLinksResponseModel> MapBOToModel(
                        List<BOPostLinks> items);
        }
}

/*<Codenesium>
    <Hash>1bcdb9ea255a715247e1419b67bcca6e</Hash>
</Codenesium>*/