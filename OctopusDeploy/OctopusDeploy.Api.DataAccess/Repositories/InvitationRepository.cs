using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class InvitationRepository : AbstractInvitationRepository, IInvitationRepository
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
    <Hash>25d540e87a5999ec7d2a9415710f2034</Hash>
</Codenesium>*/