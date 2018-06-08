using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>701bc99a47a8bbea5c68c4d09c06ae80</Hash>
</Codenesium>*/