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
                        IDALCreditCardMapper dalcreditCardMapper
                        ,
                        IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalPersonCreditCardMapper
                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper

                        )
                        : base(logger,
                               creditCardRepository,
                               creditCardModelValidator,
                               bolcreditCardMapper,
                               dalcreditCardMapper
                               ,
                               bolPersonCreditCardMapper,
                               dalPersonCreditCardMapper
                               ,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2b2a95b16a4ad121f7497c9ecd18a9e4</Hash>
</Codenesium>*/