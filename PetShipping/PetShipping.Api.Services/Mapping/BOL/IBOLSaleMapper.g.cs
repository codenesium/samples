using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLSaleMapper
        {
                BOSale MapModelToBO(
                        int id,
                        ApiSaleRequestModel model);

                ApiSaleResponseModel MapBOToModel(
                        BOSale boSale);

                List<ApiSaleResponseModel> MapBOToModel(
                        List<BOSale> items);
        }
}

/*<Codenesium>
    <Hash>a0344b97ac10457fae45d7dd5e6e31be</Hash>
</Codenesium>*/