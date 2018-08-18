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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductProductPhotoRequestModelValidatorTest
	{
		public ApiProductProductPhotoRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c125c027df5ca5606ece58f1e668272f</Hash>
</Codenesium>*/