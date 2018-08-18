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
    <Hash>643f8397712ddb7bf00f8a373959cadb</Hash>
</Codenesium>*/