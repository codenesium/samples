using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLRowVersionCheckMapper
        {
                BORowVersionCheck MapModelToBO(
                        int id,
                        ApiRowVersionCheckRequestModel model);

                ApiRowVersionCheckResponseModel MapBOToModel(
                        BORowVersionCheck boRowVersionCheck);

                List<ApiRowVersionCheckResponseModel> MapBOToModel(
                        List<BORowVersionCheck> items);
        }
}

/*<Codenesium>
    <Hash>ed91c17bb72ef1ec36f4a82b32e53b35</Hash>
</Codenesium>*/