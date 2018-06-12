using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class InvitationRepository: AbstractInvitationRepository, IInvitationRepository
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
    <Hash>45239739de5d56453eaaf3f4d37bd4e1</Hash>
</Codenesium>*/