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
                        ILogger<ICreditCardRepository> logger,
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
    <Hash>74457a8ee0cb3dab8a7614d96a909cd1</Hash>
</Codenesium>*/