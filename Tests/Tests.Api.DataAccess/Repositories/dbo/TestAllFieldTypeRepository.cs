using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>d0fe5018b3a67facfa6330e3ede01f5b</Hash>
</Codenesium>*/