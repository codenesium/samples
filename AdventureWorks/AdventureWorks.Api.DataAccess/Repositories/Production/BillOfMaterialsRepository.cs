using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>f2941e9192dec1d4929066b35b473d96</Hash>
</Codenesium>*/