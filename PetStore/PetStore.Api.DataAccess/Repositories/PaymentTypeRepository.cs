using Codenesium.DataConversionExtensions;
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
    <Hash>86e9547b8a49c019da4ae506e32074a5</Hash>
</Codenesium>*/