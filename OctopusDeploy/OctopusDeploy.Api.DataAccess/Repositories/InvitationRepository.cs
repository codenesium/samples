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
    <Hash>f61cb1d8848b443d2ccfea35e3b0595c</Hash>
</Codenesium>*/