using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPersonMapper
        {
                BOPerson MapModelToBO(
                        int businessEntityID,
                        ApiPersonRequestModel model);

                ApiPersonResponseModel MapBOToModel(
                        BOPerson boPerson);

                List<ApiPersonResponseModel> MapBOToModel(
                        List<BOPerson> items);
        }
}

/*<Codenesium>
    <Hash>9d91f4eb203b0db867ef2fbb2b639e51</Hash>
</Codenesium>*/