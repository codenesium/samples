using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>44aef7b4af0297bf8b7dec792a626161</Hash>
</Codenesium>*/