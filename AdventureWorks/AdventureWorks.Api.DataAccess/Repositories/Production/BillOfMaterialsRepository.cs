using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class BillOfMaterialsRepository : AbstractBillOfMaterialsRepository, IBillOfMaterialsRepository
        {
                public BillOfMaterialsRepository(
                        ILogger<BillOfMaterialsRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce6f90252d90332d5035cc824c9a78f0</Hash>
</Codenesium>*/