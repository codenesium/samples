using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class PaymentTypeRepository: AbstractPaymentTypeRepository, IPaymentTypeRepository
        {
                public PaymentTypeRepository(
                        ILogger<PaymentTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f69cacfe4223523245ef0986270247d8</Hash>
</Codenesium>*/