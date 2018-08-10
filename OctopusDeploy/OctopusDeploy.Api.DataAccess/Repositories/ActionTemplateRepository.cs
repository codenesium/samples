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
	public partial class ActionTemplateRepository : AbstractActionTemplateRepository, IActionTemplateRepository
	{
		public ActionTemplateRepository(
			ILogger<ActionTemplateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>074cb2e6fc4c69438a1b5aec30b9b469</Hash>
</Codenesium>*/