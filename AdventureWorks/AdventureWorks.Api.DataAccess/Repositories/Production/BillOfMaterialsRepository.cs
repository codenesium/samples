using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class BillOfMaterialsRepository : AbstractBillOfMaterialsRepository, IBillOfMaterialsRepository
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
    <Hash>5f800769f127e1fc851f9bb7ed27a2a4</Hash>
</Codenesium>*/