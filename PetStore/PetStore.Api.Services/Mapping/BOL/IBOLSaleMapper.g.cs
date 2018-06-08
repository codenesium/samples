using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>44d4849eb190594cf56662e6bec475cb</Hash>
</Codenesium>*/