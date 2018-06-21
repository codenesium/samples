using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>5d6c3aeb66861df1b02e3d5bf6931d0d</Hash>
</Codenesium>*/