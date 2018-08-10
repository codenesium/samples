using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class RowVersionCheckService : AbstractRowVersionCheckService, IRowVersionCheckService
	{
		public RowVersionCheckService(
			ILogger<IRowVersionCheckRepository> logger,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckRequestModelValidator rowVersionCheckModelValidator,
			IBOLRowVersionCheckMapper bolrowVersionCheckMapper,
			IDALRowVersionCheckMapper dalrowVersionCheckMapper
			)
			: base(logger,
			       rowVersionCheckRepository,
			       rowVersionCheckModelValidator,
			       bolrowVersionCheckMapper,
			       dalrowVersionCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ac6f65b63122e325ce0503ee69b67671</Hash>
</Codenesium>*/