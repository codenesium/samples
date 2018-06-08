using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IBOLPaymentTypeMapper
        {
                BOPaymentType MapModelToBO(
                        int id,
                        ApiPaymentTypeRequestModel model);

                ApiPaymentTypeResponseModel MapBOToModel(
                        BOPaymentType boPaymentType);

                List<ApiPaymentTypeResponseModel> MapBOToModel(
                        List<BOPaymentType> items);
        }
}

/*<Codenesium>
    <Hash>96674c5d7ea8a69641138802cac4aa63</Hash>
</Codenesium>*/