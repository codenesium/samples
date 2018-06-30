using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLClientMapper
        {
                BOClient MapModelToBO(
                        int id,
                        ApiClientRequestModel model);

                ApiClientResponseModel MapBOToModel(
                        BOClient boClient);

                List<ApiClientResponseModel> MapBOToModel(
                        List<BOClient> items);
        }
}

/*<Codenesium>
    <Hash>d5a332119c7f7a15df38bd28062bb304</Hash>
</Codenesium>*/