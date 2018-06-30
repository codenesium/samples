using Codenesium.DataConversionExtensions;
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
        public partial class PaymentTypeService : AbstractPaymentTypeService, IPaymentTypeService
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
    <Hash>5a16cde454444a0d25c4cd7fa5681a13</Hash>
</Codenesium>*/