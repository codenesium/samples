using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCreditCardMapper
        {
                BOCreditCard MapModelToBO(
                        int creditCardID,
                        ApiCreditCardRequestModel model);

                ApiCreditCardResponseModel MapBOToModel(
                        BOCreditCard boCreditCard);

                List<ApiCreditCardResponseModel> MapBOToModel(
                        List<BOCreditCard> items);
        }
}

/*<Codenesium>
    <Hash>3eacc0d4c07fc520f2b93c3a51ff68c6</Hash>
</Codenesium>*/