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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiRowVersionCheckRequestModelValidatorTest
	{
		public ApiRowVersionCheckRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateCreateAsync(new ApiRowVersionCheckRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRowVersionCheckRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateCreateAsync(new ApiRowVersionCheckRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRowVersionCheckRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>adc27d8ad4cf7797e6d93cf37ff75820</Hash>
</Codenesium>*/