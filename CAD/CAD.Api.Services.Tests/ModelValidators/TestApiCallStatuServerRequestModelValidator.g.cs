using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallStatuServerRequestModelValidatorTest
	{
		public ApiCallStatuServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICallStatuRepository> callStatuRepository = new Mock<ICallStatuRepository>();
			callStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatu()));

			var validator = new ApiCallStatuServerRequestModelValidator(callStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICallStatuRepository> callStatuRepository = new Mock<ICallStatuRepository>();
			callStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatu()));

			var validator = new ApiCallStatuServerRequestModelValidator(callStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICallStatuRepository> callStatuRepository = new Mock<ICallStatuRepository>();
			callStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatu()));

			var validator = new ApiCallStatuServerRequestModelValidator(callStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICallStatuRepository> callStatuRepository = new Mock<ICallStatuRepository>();
			callStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatu()));

			var validator = new ApiCallStatuServerRequestModelValidator(callStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>90b3803ed30ad0b12b99b7af0489fc69</Hash>
</Codenesium>*/