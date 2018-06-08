using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IBOLClaspMapper
        {
                BOClasp MapModelToBO(
                        int id,
                        ApiClaspRequestModel model);

                ApiClaspResponseModel MapBOToModel(
                        BOClasp boClasp);

                List<ApiClaspResponseModel> MapBOToModel(
                        List<BOClasp> items);
        }
}

/*<Codenesium>
    <Hash>ab1e8cb9b6dabaeb57316c8d98c18cea</Hash>
</Codenesium>*/