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
	[Trait("Table", "CallDisposition")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallDispositionServerRequestModelValidatorTest
	{
		public ApiCallDispositionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICallDispositionRepository> callDispositionRepository = new Mock<ICallDispositionRepository>();
			callDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallDisposition()));

			var validator = new ApiCallDispositionServerRequestModelValidator(callDispositionRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICallDispositionRepository> callDispositionRepository = new Mock<ICallDispositionRepository>();
			callDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallDisposition()));

			var validator = new ApiCallDispositionServerRequestModelValidator(callDispositionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICallDispositionRepository> callDispositionRepository = new Mock<ICallDispositionRepository>();
			callDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallDisposition()));

			var validator = new ApiCallDispositionServerRequestModelValidator(callDispositionRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICallDispositionRepository> callDispositionRepository = new Mock<ICallDispositionRepository>();
			callDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallDisposition()));

			var validator = new ApiCallDispositionServerRequestModelValidator(callDispositionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>10dd5327f6155cdd0a71ecf313bb4ffb</Hash>
</Codenesium>*/