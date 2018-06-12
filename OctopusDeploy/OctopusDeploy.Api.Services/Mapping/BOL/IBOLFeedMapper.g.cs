using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLFeedMapper
        {
                BOFeed MapModelToBO(
                        string id,
                        ApiFeedRequestModel model);

                ApiFeedResponseModel MapBOToModel(
                        BOFeed boFeed);

                List<ApiFeedResponseModel> MapBOToModel(
                        List<BOFeed> items);
        }
}

/*<Codenesium>
    <Hash>0db7177346b49dbcdf17caeeb89c13b8</Hash>
</Codenesium>*/