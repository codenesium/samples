using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class PaymentTypeService: AbstractPaymentTypeService, IPaymentTypeService
        {
                public PaymentTypeService(
                        ILogger<PaymentTypeRepository> logger,
                        IPaymentTypeRepository paymentTypeRepository,
                        IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
                        IBOLPaymentTypeMapper bolpaymentTypeMapper,
                        IDALPaymentTypeMapper dalpaymentTypeMapper)
                        : base(logger,
                               paymentTypeRepository,
                               paymentTypeModelValidator,
                               bolpaymentTypeMapper,
                               dalpaymentTypeMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b939252e9b7ad227c2ab24b286e8a591</Hash>
</Codenesium>*/