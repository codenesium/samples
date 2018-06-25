using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public partial class PaymentTypeRepository : AbstractPaymentTypeRepository, IPaymentTypeRepository
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
    <Hash>01a7f7cbd06c0098de73d7148b3c5496</Hash>
</Codenesium>*/