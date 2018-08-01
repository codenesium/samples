using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
	public partial class VersionInfoRepository : AbstractVersionInfoRepository, IVersionInfoRepository
	{
		public VersionInfoRepository(
			ILogger<VersionInfoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e0335eb4e8c744f578559b74b23bd043</Hash>
</Codenesium>*/