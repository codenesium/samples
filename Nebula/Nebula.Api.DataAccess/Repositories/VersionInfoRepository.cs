using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class VersionInfoRepository: AbstractVersionInfoRepository, IVersionInfoRepository
	{
		public VersionInfoRepository(
			ILogger<VersionInfoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>d9f6fd4ab4f7d73e4a208332a18e7bba</Hash>
</Codenesium>*/