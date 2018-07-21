using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLPersonMapper
        {
                BOPerson MapModelToBO(
                        int personId,
                        ApiPersonRequestModel model);

                ApiPersonResponseModel MapBOToModel(
                        BOPerson boPerson);

                List<ApiPersonResponseModel> MapBOToModel(
                        List<BOPerson> items);
        }
}

/*<Codenesium>
    <Hash>e18138844f3df00e33196134c4bce353</Hash>
</Codenesium>*/