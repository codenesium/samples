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
	[Trait("Table", "BusinessEntityContact")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBusinessEntityContactRequestModelValidatorTest
	{
		public ApiBusinessEntityContactRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1868cb15e094583a563ba7602a626a8f</Hash>
</Codenesium>*/