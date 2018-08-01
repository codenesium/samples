using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class VariableSetRepository : AbstractVariableSetRepository, IVariableSetRepository
	{
		public VariableSetRepository(
			ILogger<VariableSetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7a4d1cf5bf6d536e1d508ae5ae731275</Hash>
</Codenesium>*/