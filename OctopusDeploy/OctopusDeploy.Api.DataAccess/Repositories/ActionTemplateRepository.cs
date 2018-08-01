using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>8a2bf5eebdbc8bbace064b206dfad7dd</Hash>
</Codenesium>*/