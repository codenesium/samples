using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>9a40c0c40560259c9cf78ae0102ad822</Hash>
</Codenesium>*/