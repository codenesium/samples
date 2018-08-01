using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
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
    <Hash>c690d22969f7d8a44c71c3eb55d258d4</Hash>
</Codenesium>*/