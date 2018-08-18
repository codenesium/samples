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
    <Hash>aec6debfbf80c3b2870b3e20c2bf4918</Hash>
</Codenesium>*/