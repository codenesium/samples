using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>61ead50388649b89d0261f1782580ac7</Hash>
</Codenesium>*/