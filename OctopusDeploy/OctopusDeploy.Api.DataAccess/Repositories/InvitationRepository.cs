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
    <Hash>78da35283733f122a5814e4fe7cd5725</Hash>
</Codenesium>*/