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
    <Hash>ff92e9b4f76203a26a4fb8dcd4e505bc</Hash>
</Codenesium>*/