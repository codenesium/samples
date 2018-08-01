using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
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
    <Hash>04410e4dc08d3a4df51c02ee5410d7dc</Hash>
</Codenesium>*/