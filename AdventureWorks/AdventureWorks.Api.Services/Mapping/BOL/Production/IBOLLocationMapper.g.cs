using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLLocationMapper
        {
                BOLocation MapModelToBO(
                        short locationID,
                        ApiLocationRequestModel model);

                ApiLocationResponseModel MapBOToModel(
                        BOLocation boLocation);

                List<ApiLocationResponseModel> MapBOToModel(
                        List<BOLocation> items);
        }
}

/*<Codenesium>
    <Hash>3952f3b17d707624f89b0172845d8e77</Hash>
</Codenesium>*/