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
                        ILogger<IPaymentTypeRepository> logger,
                        IPaymentTypeRepository paymentTypeRepository,
                        IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
                        IBOLPaymentTypeMapper bolpaymentTypeMapper,
                        IDALPaymentTypeMapper dalpaymentTypeMapper
                        ,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper

                        )
                        : base(logger,
                               paymentTypeRepository,
                               paymentTypeModelValidator,
                               bolpaymentTypeMapper,
                               dalpaymentTypeMapper
                               ,
                               bolSaleMapper,
                               dalSaleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>30676103265765bd3840075e9a41b5c2</Hash>
</Codenesium>*/