using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class IllustrationRepository: AbstractIllustrationRepository, IIllustrationRepository
	{
		public IllustrationRepository(
			IObjectMapper mapper,
			ILogger<IllustrationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f646c7932447a32a839cc90f81939a80</Hash>
</Codenesium>*/