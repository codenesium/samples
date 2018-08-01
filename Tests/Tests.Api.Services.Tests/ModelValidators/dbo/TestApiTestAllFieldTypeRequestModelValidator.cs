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
	[Trait("Table", "TestAllFieldType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTestAllFieldTypeRequestModelValidatorTest
	{
		public ApiTestAllFieldTypeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FieldBinary_Create_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldBinary, new byte[51]);
		}

		[Fact]
		public async void FieldBinary_Update_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldBinary, new byte[51]);
		}

		[Fact]
		public async void FieldChar_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, null as string);
		}

		[Fact]
		public async void FieldChar_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, null as string);
		}

		[Fact]
		public async void FieldChar_Create_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, new string('A', 11));
		}

		[Fact]
		public async void FieldChar_Update_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNChar_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, null as string);
		}

		[Fact]
		public async void FieldNChar_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, null as string);
		}

		[Fact]
		public async void FieldNChar_Create_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNChar_Update_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNChar, new string('A', 11));
		}

		[Fact]
		public async void FieldNText_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNText, null as string);
		}

		[Fact]
		public async void FieldNText_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNText, null as string);
		}

		[Fact]
		public async void FieldNVarchar_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, null as string);
		}

		[Fact]
		public async void FieldNVarchar_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, null as string);
		}

		[Fact]
		public async void FieldNVarchar_Create_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldNVarchar_Update_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldNVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldText_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldText, null as string);
		}

		[Fact]
		public async void FieldText_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldText, null as string);
		}

		[Fact]
		public async void FieldVarBinary_Create_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarBinary, new byte[51]);
		}

		[Fact]
		public async void FieldVarBinary_Update_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarBinary, new byte[51]);
		}

		[Fact]
		public async void FieldVarchar_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, null as string);
		}

		[Fact]
		public async void FieldVarchar_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, null as string);
		}

		[Fact]
		public async void FieldVarchar_Create_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldVarchar_Update_length()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldVarchar, new string('A', 51));
		}

		[Fact]
		public async void FieldXML_Create_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldXML, null as string);
		}

		[Fact]
		public async void FieldXML_Update_null()
		{
			Mock<ITestAllFieldTypeRepository> testAllFieldTypeRepository = new Mock<ITestAllFieldTypeRepository>();
			testAllFieldTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldType()));

			var validator = new ApiTestAllFieldTypeRequestModelValidator(testAllFieldTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTestAllFieldTypeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FieldXML, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>46098b372db7dbd8792bdd6733a8ac1c</Hash>
</Codenesium>*/