using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class InvitationService: AbstractInvitationService, IInvitationService
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
                               dalinvitationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>fc46bce49cc04429d8e191d22ade780f</Hash>
</Codenesium>*/