using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EmployeePayHistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEmployeePayHistoryRequestModelValidatorTest
	{
		public ApiEmployeePayHistoryRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>cc2ad7ac8fbfed69ca4c4e449a5b0ba1</Hash>
</Codenesium>*/