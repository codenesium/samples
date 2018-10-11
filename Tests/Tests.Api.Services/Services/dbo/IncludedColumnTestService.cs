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
	public partial class IncludedColumnTestService : AbstractIncludedColumnTestService, IIncludedColumnTestService
	{
		public IncludedColumnTestService(
			ILogger<IIncludedColumnTestRepository> logger,
			IIncludedColumnTestRepository includedColumnTestRepository,
			IApiIncludedColumnTestRequestModelValidator includedColumnTestModelValidator,
			IBOLIncludedColumnTestMapper bolincludedColumnTestMapper,
			IDALIncludedColumnTestMapper dalincludedColumnTestMapper)
			: base(logger,
			       includedColumnTestRepository,
			       includedColumnTestModelValidator,
			       bolincludedColumnTestMapper,
			       dalincludedColumnTestMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fc0c474b79433032552da4a5e0d7f56c</Hash>
</Codenesium>*/