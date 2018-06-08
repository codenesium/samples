using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>2186af1bbb43483e310f261d1ea13432</Hash>
</Codenesium>*/