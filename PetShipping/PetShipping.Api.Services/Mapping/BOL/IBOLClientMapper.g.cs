using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>b63ad6da75ed17502e96a51c2289181e</Hash>
</Codenesium>*/