using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class StateRepository : AbstractStateRepository, IStateRepository
        {
                public StateRepository(
                        ILogger<StateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c01f40bc5128d4c6607aa3da622602d7</Hash>
</Codenesium>*/