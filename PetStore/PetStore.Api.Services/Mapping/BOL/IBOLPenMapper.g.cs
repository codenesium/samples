using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>3179bf8243e6ec00b9cf02229ee91b29</Hash>
</Codenesium>*/