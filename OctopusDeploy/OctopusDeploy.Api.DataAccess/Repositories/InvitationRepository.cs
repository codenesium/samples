using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>10d5b858784eedbe8d8ffa67257abc91</Hash>
</Codenesium>*/