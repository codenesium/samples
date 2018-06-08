using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>f02380eb74ddaca33286cf21c750f8ec</Hash>
</Codenesium>*/