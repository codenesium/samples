using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class CreditCardService: AbstractCreditCardService, ICreditCardService
        {
                public CreditCardService(
                        ILogger<CreditCardRepository> logger,
                        ICreditCardRepository creditCardRepository,
                        IApiCreditCardRequestModelValidator creditCardModelValidator,
                        IBOLCreditCardMapper bolcreditCardMapper,
                        IDALCreditCardMapper dalcreditCardMapper)
                        : base(logger,
                               creditCardRepository,
                               creditCardModelValidator,
                               bolcreditCardMapper,
                               dalcreditCardMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>64abdee31f5ccf1c4a2d3679a9cc9ba9</Hash>
</Codenesium>*/