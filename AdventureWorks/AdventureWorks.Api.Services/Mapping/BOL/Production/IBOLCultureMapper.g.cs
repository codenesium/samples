using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>57f3af21b4ee5871b275ee92549d9bcf</Hash>
</Codenesium>*/