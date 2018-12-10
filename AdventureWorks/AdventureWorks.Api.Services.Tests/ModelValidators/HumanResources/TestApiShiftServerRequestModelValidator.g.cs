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
	[Trait("Table", "Shift")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiShiftServerRequestModelValidatorTest
	{
		public ApiShiftServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Shift>(new Shift()));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Shift>(null));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Shift>(new Shift()));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Shift>(null));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>ab1be90c4a9eaedd5da5c03ae6a88de2</Hash>
</Codenesium>*/