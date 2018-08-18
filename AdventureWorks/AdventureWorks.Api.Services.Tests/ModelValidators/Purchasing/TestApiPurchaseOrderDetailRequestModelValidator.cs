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
	[Trait("Table", "PurchaseOrderDetail")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPurchaseOrderDetailRequestModelValidatorTest
	{
		public ApiPurchaseOrderDetailRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2b414c0b89dd63befde53a96b5a3fd08</Hash>
</Codenesium>*/