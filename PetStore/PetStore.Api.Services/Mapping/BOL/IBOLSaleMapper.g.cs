using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>08aab4be8ff8338003a1477b0aeb66db</Hash>
</Codenesium>*/