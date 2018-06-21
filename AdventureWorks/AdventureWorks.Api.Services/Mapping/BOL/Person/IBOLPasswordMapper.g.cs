using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPasswordMapper
        {
                BOPassword MapModelToBO(
                        int businessEntityID,
                        ApiPasswordRequestModel model);

                ApiPasswordResponseModel MapBOToModel(
                        BOPassword boPassword);

                List<ApiPasswordResponseModel> MapBOToModel(
                        List<BOPassword> items);
        }
}

/*<Codenesium>
    <Hash>2c35846036b03f053f3e0a38c162f15b</Hash>
</Codenesium>*/