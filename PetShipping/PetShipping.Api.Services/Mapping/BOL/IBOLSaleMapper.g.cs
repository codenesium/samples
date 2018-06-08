using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>c1850d2ad39bf46035f98796f2a3eae0</Hash>
</Codenesium>*/