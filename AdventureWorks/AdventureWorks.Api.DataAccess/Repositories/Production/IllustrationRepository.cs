using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class IllustrationRepository: AbstractIllustrationRepository, IIllustrationRepository
	{
		public IllustrationRepository(
			ILogger<IllustrationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>076570a3809cdf6f4c62e7b513981df3</Hash>
</Codenesium>*/