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
	public partial class CommunityActionTemplateService : AbstractCommunityActionTemplateService, ICommunityActionTemplateService
	{
		public CommunityActionTemplateService(
			ILogger<ICommunityActionTemplateRepository> logger,
			ICommunityActionTemplateRepository communityActionTemplateRepository,
			IApiCommunityActionTemplateRequestModelValidator communityActionTemplateModelValidator,
			IBOLCommunityActionTemplateMapper bolcommunityActionTemplateMapper,
			IDALCommunityActionTemplateMapper dalcommunityActionTemplateMapper
			)
			: base(logger,
			       communityActionTemplateRepository,
			       communityActionTemplateModelValidator,
			       bolcommunityActionTemplateMapper,
			       dalcommunityActionTemplateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>506d89654d14a1c558a895666ce3cce6</Hash>
</Codenesium>*/