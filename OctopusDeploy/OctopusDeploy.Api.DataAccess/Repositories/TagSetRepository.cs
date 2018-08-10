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
    <Hash>da740e982bda042bfd228212bb24b45e</Hash>
</Codenesium>*/