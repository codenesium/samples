using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ActionTemplateVersionService : AbstractActionTemplateVersionService, IActionTemplateVersionService
	{
		public ActionTemplateVersionService(
			ILogger<IActionTemplateVersionRepository> logger,
			IActionTemplateVersionRepository actionTemplateVersionRepository,
			IApiActionTemplateVersionRequestModelValidator actionTemplateVersionModelValidator,
			IBOLActionTemplateVersionMapper bolactionTemplateVersionMapper,
			IDALActionTemplateVersionMapper dalactionTemplateVersionMapper
			)
			: base(logger,
			       actionTemplateVersionRepository,
			       actionTemplateVersionModelValidator,
			       bolactionTemplateVersionMapper,
			       dalactionTemplateVersionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>990688a1d965ddf329b0a250bc3d8cc0</Hash>
</Codenesium>*/