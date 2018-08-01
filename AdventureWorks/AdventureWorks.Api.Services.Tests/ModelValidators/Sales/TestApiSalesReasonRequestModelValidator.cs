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
	[Trait("Table", "SalesReason")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesReasonRequestModelValidatorTest
	{
		public ApiSalesReasonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void ReasonType_Create_null()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReasonType, null as string);
		}

		[Fact]
		public async void ReasonType_Update_null()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReasonType, null as string);
		}

		[Fact]
		public async void ReasonType_Create_length()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReasonType, new string('A', 51));
		}

		[Fact]
		public async void ReasonType_Update_length()
		{
			Mock<ISalesReasonRepository> salesReasonRepository = new Mock<ISalesReasonRepository>();
			salesReasonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));

			var validator = new ApiSalesReasonRequestModelValidator(salesReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesReasonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReasonType, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>d7c9110945a3a1f05fec7dfe50309a50</Hash>
</Codenesium>*/