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
	public partial class ApiRowVersionCheckServerRequestModelValidatorTest
	{
		public ApiRowVersionCheckServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckServerRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateCreateAsync(new ApiRowVersionCheckServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckServerRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRowVersionCheckServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckServerRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateCreateAsync(new ApiRowVersionCheckServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IRowVersionCheckRepository> rowVersionCheckRepository = new Mock<IRowVersionCheckRepository>();
			rowVersionCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new RowVersionCheck()));

			var validator = new ApiRowVersionCheckServerRequestModelValidator(rowVersionCheckRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRowVersionCheckServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>59974c483e3e718d45f8d132472ccc67</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/