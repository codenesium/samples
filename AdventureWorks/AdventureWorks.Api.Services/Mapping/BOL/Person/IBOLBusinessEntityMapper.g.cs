using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLBusinessEntityMapper
        {
                BOBusinessEntity MapModelToBO(
                        int businessEntityID,
                        ApiBusinessEntityRequestModel model);

                ApiBusinessEntityResponseModel MapBOToModel(
                        BOBusinessEntity boBusinessEntity);

                List<ApiBusinessEntityResponseModel> MapBOToModel(
                        List<BOBusinessEntity> items);
        }
}

/*<Codenesium>
    <Hash>3fe65c1b1efedb879bc8758ca162de2b</Hash>
</Codenesium>*/