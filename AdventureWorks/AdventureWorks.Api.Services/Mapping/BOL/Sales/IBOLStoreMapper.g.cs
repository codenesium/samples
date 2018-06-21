using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>64e15ab5eebf8bfca3dd71089fee8aab</Hash>
</Codenesium>*/