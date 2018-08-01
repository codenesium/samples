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
	public partial class ApiIllustrationRequestModelValidatorTest
	{
		public ApiIllustrationRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>66c80aace74deee0ff9697ad27f6f000</Hash>
</Codenesium>*/