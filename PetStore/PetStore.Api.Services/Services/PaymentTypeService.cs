using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
        public class PaymentTypeService : AbstractPaymentTypeService, IPaymentTypeService
        {
                public PaymentTypeService(
                        ILogger<IPaymentTypeRepository> logger,
                        IPaymentTypeRepository paymentTypeRepository,
                        IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
                        IBOLPaymentTypeMapper bolpaymentTypeMapper,
                        IDALPaymentTypeMapper dalpaymentTypeMapper,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper
                        )
                        : base(logger,
                               paymentTypeRepository,
                               paymentTypeModelValidator,
                               bolpaymentTypeMapper,
                               dalpaymentTypeMapper,
                               bolSaleMapper,
                               dalSaleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ff247244b5a868d9d694420e1f957c6b</Hash>
</Codenesium>*/