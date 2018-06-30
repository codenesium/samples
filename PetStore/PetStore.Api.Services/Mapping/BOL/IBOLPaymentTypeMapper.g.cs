using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0a7261e6e7432bb9508479ffd22aa723</Hash>
</Codenesium>*/