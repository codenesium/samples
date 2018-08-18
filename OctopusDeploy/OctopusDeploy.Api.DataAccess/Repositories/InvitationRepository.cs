using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>59a5205b7fd6a1409b002157a25b5160</Hash>
</Codenesium>*/