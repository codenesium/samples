using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpeciesServerRequestModelValidatorTest
	{
		public ApiSpeciesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
			speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

			var validator = new ApiSpeciesServerRequestModelValidator(speciesRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpeciesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
			speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

			var validator = new ApiSpeciesServerRequestModelValidator(speciesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpeciesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
			speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

			var validator = new ApiSpeciesServerRequestModelValidator(speciesRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpeciesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISpeciesRepository> speciesRepository = new Mock<ISpeciesRepository>();
			speciesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));

			var validator = new ApiSpeciesServerRequestModelValidator(speciesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpeciesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>5150064fb73303bca298ed9ae942179e</Hash>
</Codenesium>*/