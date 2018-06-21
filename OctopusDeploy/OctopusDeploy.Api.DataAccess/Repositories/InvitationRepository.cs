using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class InvitationRepository : AbstractInvitationRepository, IInvitationRepository
        {
                public InvitationRepository(
                        ILogger<InvitationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>611219ad4e284b32be3beef5502d9fa2</Hash>
</Codenesium>*/