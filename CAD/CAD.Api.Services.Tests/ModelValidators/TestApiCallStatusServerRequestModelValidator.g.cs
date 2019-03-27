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
	[Trait("Table", "CallStatus")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallStatusServerRequestModelValidatorTest
	{
		public ApiCallStatusServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICallStatusRepository> callStatusRepository = new Mock<ICallStatusRepository>();
			callStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatus()));

			var validator = new ApiCallStatusServerRequestModelValidator(callStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICallStatusRepository> callStatusRepository = new Mock<ICallStatusRepository>();
			callStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatus()));

			var validator = new ApiCallStatusServerRequestModelValidator(callStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICallStatusRepository> callStatusRepository = new Mock<ICallStatusRepository>();
			callStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatus()));

			var validator = new ApiCallStatusServerRequestModelValidator(callStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICallStatusRepository> callStatusRepository = new Mock<ICallStatusRepository>();
			callStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatus()));

			var validator = new ApiCallStatusServerRequestModelValidator(callStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>1dcc22cfcd3ca7fea65c0111608ee7b7</Hash>
</Codenesium>*/