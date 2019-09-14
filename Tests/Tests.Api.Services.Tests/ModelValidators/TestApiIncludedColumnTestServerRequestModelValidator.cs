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
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiIncludedColumnTestServerRequestModelValidatorTest
	{
		public ApiIncludedColumnTestServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateCreateAsync(new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateCreateAsync(new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name2_Create_null()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateCreateAsync(new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name2, null as string);
		}

		[Fact]
		public async void Name2_Update_null()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name2, null as string);
		}

		[Fact]
		public async void Name2_Create_length()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateCreateAsync(new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name2, new string('A', 51));
		}

		[Fact]
		public async void Name2_Update_length()
		{
			Mock<IIncludedColumnTestRepository> includedColumnTestRepository = new Mock<IIncludedColumnTestRepository>();
			includedColumnTestRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new IncludedColumnTest()));

			var validator = new ApiIncludedColumnTestServerRequestModelValidator(includedColumnTestRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiIncludedColumnTestServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name2, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>d8a2263f86e880e828ddb1a939f216b6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/