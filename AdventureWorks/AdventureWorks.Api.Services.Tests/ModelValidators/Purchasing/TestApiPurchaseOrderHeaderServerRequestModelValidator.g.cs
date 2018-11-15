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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPurchaseOrderHeaderServerRequestModelValidatorTest
	{
		public ApiPurchaseOrderHeaderServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>73112dfcc6a6bf9b8913c4cfaece6b3f</Hash>
</Codenesium>*/