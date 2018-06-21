using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a3d8a305c924f6601f9d95fceee72ab5</Hash>
</Codenesium>*/