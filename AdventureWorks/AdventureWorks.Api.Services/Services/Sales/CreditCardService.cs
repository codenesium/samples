using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class CreditCardService : AbstractCreditCardService, ICreditCardService
        {
                public CreditCardService(
                        ILogger<ICreditCardRepository> logger,
                        ICreditCardRepository creditCardRepository,
                        IApiCreditCardRequestModelValidator creditCardModelValidator,
                        IBOLCreditCardMapper bolcreditCardMapper,
                        IDALCreditCardMapper dalcreditCardMapper,
                        IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
                        IDALPersonCreditCardMapper dalPersonCreditCardMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        )
                        : base(logger,
                               creditCardRepository,
                               creditCardModelValidator,
                               bolcreditCardMapper,
                               dalcreditCardMapper,
                               bolPersonCreditCardMapper,
                               dalPersonCreditCardMapper,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ac7420eda5775069b22fb08bdda7d4e0</Hash>
</Codenesium>*/