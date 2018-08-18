using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>7e278acfdb18cf0e2d4b5ff8c9e1900e</Hash>
</Codenesium>*/