using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>42b5e4ed9913d28957a7bfd2c798b5b2</Hash>
</Codenesium>*/