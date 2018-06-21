using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>92f88f58b38481f589e6c5a85f846293</Hash>
</Codenesium>*/