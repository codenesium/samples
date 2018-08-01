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
	[Trait("Table", "BusinessEntityAddress")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBusinessEntityAddressRequestModelValidatorTest
	{
		public ApiBusinessEntityAddressRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8481c2cab58f20c78cff0bb206604592</Hash>
</Codenesium>*/