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
	[Trait("Table", "Illustration")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiIllustrationServerRequestModelValidatorTest
	{
		public ApiIllustrationServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3864a98ef667883cd114f12048271960</Hash>
</Codenesium>*/