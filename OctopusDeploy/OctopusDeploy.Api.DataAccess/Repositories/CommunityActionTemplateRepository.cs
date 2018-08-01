using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class CommunityActionTemplateRepository : AbstractCommunityActionTemplateRepository, ICommunityActionTemplateRepository
	{
		public CommunityActionTemplateRepository(
			ILogger<CommunityActionTemplateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7afe73a6f2271bf08d0787f46a885d91</Hash>
</Codenesium>*/