using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class TagSetRepository : AbstractTagSetRepository, ITagSetRepository
	{
		public TagSetRepository(
			ILogger<TagSetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>04a31caa9703a6be153ea05c4db7d6c1</Hash>
</Codenesium>*/