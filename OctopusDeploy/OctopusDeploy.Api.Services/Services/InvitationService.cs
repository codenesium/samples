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
    <Hash>f6cb6c30cf5cd6e9abe756a14bb9f066</Hash>
</Codenesium>*/