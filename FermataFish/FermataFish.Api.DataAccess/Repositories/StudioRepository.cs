using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class StudioRepository : AbstractStudioRepository, IStudioRepository
        {
                public StudioRepository(
                        ILogger<StudioRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>731a3155e8d31b53c193624047fe7a59</Hash>
</Codenesium>*/