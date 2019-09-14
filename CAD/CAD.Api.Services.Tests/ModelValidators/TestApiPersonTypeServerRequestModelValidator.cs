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
	[Trait("Table", "PersonType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonTypeServerRequestModelValidatorTest
	{
		public ApiPersonTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPersonTypeRepository> personTypeRepository = new Mock<IPersonTypeRepository>();
			personTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonType()));

			var validator = new ApiPersonTypeServerRequestModelValidator(personTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPersonTypeRepository> personTypeRepository = new Mock<IPersonTypeRepository>();
			personTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonType()));

			var validator = new ApiPersonTypeServerRequestModelValidator(personTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPersonTypeRepository> personTypeRepository = new Mock<IPersonTypeRepository>();
			personTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonType()));

			var validator = new ApiPersonTypeServerRequestModelValidator(personTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPersonTypeRepository> personTypeRepository = new Mock<IPersonTypeRepository>();
			personTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonType()));

			var validator = new ApiPersonTypeServerRequestModelValidator(personTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>2dd4486a9551ebf1d5e9f27a97f783ef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/