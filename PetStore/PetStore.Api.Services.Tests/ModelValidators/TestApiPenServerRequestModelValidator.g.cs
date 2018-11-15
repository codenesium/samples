using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pen")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPenServerRequestModelValidatorTest
	{
		public ApiPenServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
			penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

			var validator = new ApiPenServerRequestModelValidator(penRepository.Object);
			await validator.ValidateCreateAsync(new ApiPenServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
			penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

			var validator = new ApiPenServerRequestModelValidator(penRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPenServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
			penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

			var validator = new ApiPenServerRequestModelValidator(penRepository.Object);
			await validator.ValidateCreateAsync(new ApiPenServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
			penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

			var validator = new ApiPenServerRequestModelValidator(penRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPenServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>1d1bc95db84583fbe70d02d979971684</Hash>
</Codenesium>*/