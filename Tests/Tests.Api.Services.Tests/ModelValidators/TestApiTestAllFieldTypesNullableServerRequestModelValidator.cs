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
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTestAllFieldTypesNullableServerRequestModelValidatorTest
	{
		public ApiTestAllFieldTypesNullableServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FieldBinary_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldBinary, new byte[51]);
		}

		[Fact]
		public async void FieldBinary_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldBinary, new byte[51]);
		}

		[Fact]
		public async void FieldChar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, new string('A', 11));
		}

		[Fact]
		public async void FieldChar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNChar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNChar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNVarchar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldNVarchar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldVarBinary_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarBinary, new byte[51]);
		}

		[Fact]
		public async void FieldVarBinary_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarBinary, new byte[51]);
		}

		[Fact]
		public async void FieldVarchar_Create_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldVarchar_Update_length()
		{
			Mock<ITestAllFieldTypesNullableRepository> testAllFieldTypesNullableRepository = new Mock<ITestAllFieldTypesNullableRepository>();
			testAllFieldTypesNullableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));

			var validator = new ApiTestAllFieldTypesNullableServerRequestModelValidator(testAllFieldTypesNullableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypesNullableServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>bb3985d7cd26d2b23089f8fa23c43004</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/