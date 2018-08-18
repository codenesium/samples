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
    <Hash>6c0380302d32facf863abff1c7bdd145</Hash>
</Codenesium>*/