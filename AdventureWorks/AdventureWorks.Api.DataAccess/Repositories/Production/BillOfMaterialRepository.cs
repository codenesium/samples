using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class BillOfMaterialRepository : AbstractBillOfMaterialRepository, IBillOfMaterialRepository
        {
                public BillOfMaterialRepository(
                        ILogger<BillOfMaterialRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9e01be1e9f3a4e992470e36442485987</Hash>
</Codenesium>*/