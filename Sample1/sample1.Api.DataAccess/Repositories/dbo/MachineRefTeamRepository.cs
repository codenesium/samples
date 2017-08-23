using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using sample1NS.Api.Contracts;

namespace sample1NS.Api.DataAccess
{
	public class MachineRefTeamRepository: AbstractMachineRefTeamRepository
	{
		public MachineRefTeamRepository(ILogger logger,
		                                DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>ff97dfa927fd426b533de7f31cb19508</Hash>
</Codenesium>*/