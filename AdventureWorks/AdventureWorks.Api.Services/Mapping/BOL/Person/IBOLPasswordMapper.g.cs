using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>ba25dac5d890b227853836a45683cf65</Hash>
</Codenesium>*/