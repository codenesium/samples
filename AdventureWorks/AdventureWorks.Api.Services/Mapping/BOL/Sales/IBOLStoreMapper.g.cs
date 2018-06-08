using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLStoreMapper
        {
                BOStore MapModelToBO(
                        int businessEntityID,
                        ApiStoreRequestModel model);

                ApiStoreResponseModel MapBOToModel(
                        BOStore boStore);

                List<ApiStoreResponseModel> MapBOToModel(
                        List<BOStore> items);
        }
}

/*<Codenesium>
    <Hash>d760001f5bae949b58975cc69415bc90</Hash>
</Codenesium>*/