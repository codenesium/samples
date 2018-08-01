using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class MachineRepository : AbstractMachineRepository, IMachineRepository
	{
		public MachineRepository(
			ILogger<MachineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e3b9e0520ae43683106f65239a9e208</Hash>
</Codenesium>*/