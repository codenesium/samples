using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPersonCreditCardMapper
        {
                BOPersonCreditCard MapModelToBO(
                        int businessEntityID,
                        ApiPersonCreditCardRequestModel model);

                ApiPersonCreditCardResponseModel MapBOToModel(
                        BOPersonCreditCard boPersonCreditCard);

                List<ApiPersonCreditCardResponseModel> MapBOToModel(
                        List<BOPersonCreditCard> items);
        }
}

/*<Codenesium>
    <Hash>f7b2f67ecc981e136ad8e850ecc4c81c</Hash>
</Codenesium>*/