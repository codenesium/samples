using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class PaymentTypeRepository : AbstractPaymentTypeRepository, IPaymentTypeRepository
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
    <Hash>07354337628befa24ec37391b3170a74</Hash>
</Codenesium>*/