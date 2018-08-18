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
	[Trait("Table", "SpecialOfferProduct")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpecialOfferProductRequestModelValidatorTest
	{
		public ApiSpecialOfferProductRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1cf5c8b26b5e3ccad7dca1c332b7bfc0</Hash>
</Codenesium>*/