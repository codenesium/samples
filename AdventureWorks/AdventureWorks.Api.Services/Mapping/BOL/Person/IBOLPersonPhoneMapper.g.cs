using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPersonPhoneMapper
        {
                BOPersonPhone MapModelToBO(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel model);

                ApiPersonPhoneResponseModel MapBOToModel(
                        BOPersonPhone boPersonPhone);

                List<ApiPersonPhoneResponseModel> MapBOToModel(
                        List<BOPersonPhone> items);
        }
}

/*<Codenesium>
    <Hash>dc1cb41935963b37ae93497713f41d95</Hash>
</Codenesium>*/