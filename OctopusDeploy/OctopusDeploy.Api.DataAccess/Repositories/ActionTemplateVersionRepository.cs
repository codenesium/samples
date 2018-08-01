using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>12081f71fed5c83985c9e16c6c555358</Hash>
</Codenesium>*/