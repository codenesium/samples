using Codenesium.DataConversionExtensions;
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
	public partial class InvitationService : AbstractInvitationService, IInvitationService
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
    <Hash>2c5381e4bc9e5c984003120d001d3bfc</Hash>
</Codenesium>*/