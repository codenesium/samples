using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial class MachineRefTeamRepository : AbstractMachineRefTeamRepository, IMachineRefTeamRepository
	{
		public MachineRefTeamRepository(
			ILogger<MachineRefTeamRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1fe87a559c35c3f8b0c8ac1b8295c820</Hash>
</Codenesium>*/