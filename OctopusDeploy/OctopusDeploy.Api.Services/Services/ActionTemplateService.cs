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
	public partial class ActionTemplateService : AbstractActionTemplateService, IActionTemplateService
	{
		public ActionTemplateService(
			ILogger<IActionTemplateRepository> logger,
			IActionTemplateRepository actionTemplateRepository,
			IApiActionTemplateRequestModelValidator actionTemplateModelValidator,
			IBOLActionTemplateMapper bolactionTemplateMapper,
			IDALActionTemplateMapper dalactionTemplateMapper
			)
			: base(logger,
			       actionTemplateRepository,
			       actionTemplateModelValidator,
			       bolactionTemplateMapper,
			       dalactionTemplateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>592fc75d339559353eb940978e54a375</Hash>
</Codenesium>*/