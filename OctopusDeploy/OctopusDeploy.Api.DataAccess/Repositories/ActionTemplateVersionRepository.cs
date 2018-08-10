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
	public partial class ActionTemplateVersionRepository : AbstractActionTemplateVersionRepository, IActionTemplateVersionRepository
	{
		public ActionTemplateVersionRepository(
			ILogger<ActionTemplateVersionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4b4b8f6a2addc4b07f5bb823cca4d892</Hash>
</Codenesium>*/