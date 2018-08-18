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
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBusinessEntityRequestModelValidatorTest
	{
		public ApiBusinessEntityRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4b548f3e0795ec7361cf0f7057c7fdc3</Hash>
</Codenesium>*/