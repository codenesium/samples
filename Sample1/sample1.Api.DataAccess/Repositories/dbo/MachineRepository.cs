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
	public class MachineRepository: AbstractMachineRepository
	{
		public MachineRepository(ILogger logger,
		                         DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>374f6c0e0b4d6c5132e3b04891a221f6</Hash>
</Codenesium>*/