using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>eaf184d263a659a432a4bf6a999f7bc3</Hash>
</Codenesium>*/