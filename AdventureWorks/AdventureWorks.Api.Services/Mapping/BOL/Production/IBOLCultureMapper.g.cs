using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCultureMapper
        {
                BOCulture MapModelToBO(
                        string cultureID,
                        ApiCultureRequestModel model);

                ApiCultureResponseModel MapBOToModel(
                        BOCulture boCulture);

                List<ApiCultureResponseModel> MapBOToModel(
                        List<BOCulture> items);
        }
}

/*<Codenesium>
    <Hash>2d7243821d6f5834187c8ce57eae94de</Hash>
</Codenesium>*/