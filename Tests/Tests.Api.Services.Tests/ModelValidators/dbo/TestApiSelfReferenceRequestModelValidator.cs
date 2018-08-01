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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSelfReferenceRequestModelValidatorTest
	{
		public ApiSelfReferenceRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f4a23e58eb5a505c46dcd6f869a4a3cc</Hash>
</Codenesium>*/