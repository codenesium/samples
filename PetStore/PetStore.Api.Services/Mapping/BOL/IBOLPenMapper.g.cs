using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IBOLPenMapper
        {
                BOPen MapModelToBO(
                        int id,
                        ApiPenRequestModel model);

                ApiPenResponseModel MapBOToModel(
                        BOPen boPen);

                List<ApiPenResponseModel> MapBOToModel(
                        List<BOPen> items);
        }
}

/*<Codenesium>
    <Hash>42cab10d303c30373119a38dba22f077</Hash>
</Codenesium>*/