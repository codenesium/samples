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
    <Hash>a24585230fe97704ef5539bf78e5c1ba</Hash>
</Codenesium>*/