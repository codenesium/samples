using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class InvitationService : AbstractInvitationService, IInvitationService
        {
                public InvitationService(
                        ILogger<IInvitationRepository> logger,
                        IInvitationRepository invitationRepository,
                        IApiInvitationRequestModelValidator invitationModelValidator,
                        IBOLInvitationMapper bolinvitationMapper,
                        IDALInvitationMapper dalinvitationMapper
                        )
                        : base(logger,
                               invitationRepository,
                               invitationModelValidator,
                               bolinvitationMapper,
                               dalinvitationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1ac37e79d6d6d9b3cfda5b1f0f5ec202</Hash>
</Codenesium>*/