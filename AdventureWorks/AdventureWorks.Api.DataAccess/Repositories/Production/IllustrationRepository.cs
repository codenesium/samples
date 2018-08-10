using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class IllustrationRepository : AbstractIllustrationRepository, IIllustrationRepository
	{
		public IllustrationRepository(
			ILogger<IllustrationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d62a40d0399129c606312a2d73f3f7df</Hash>
</Codenesium>*/