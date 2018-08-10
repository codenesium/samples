using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial class TestAllFieldTypeRepository : AbstractTestAllFieldTypeRepository, ITestAllFieldTypeRepository
	{
		public TestAllFieldTypeRepository(
			ILogger<TestAllFieldTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>db5814fdd07b28d3d60957f36698ae8f</Hash>
</Codenesium>*/