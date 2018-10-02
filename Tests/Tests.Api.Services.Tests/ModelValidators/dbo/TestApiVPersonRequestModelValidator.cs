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
	[Trait("Table", "VPerson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVPersonRequestModelValidatorTest
	{
		public ApiVPersonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PersonName_Create_null()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiVPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Update_null()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Create_length()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiVPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}

		[Fact]
		public async void PersonName_Update_length()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>bcb500023d9a9007b948105a70bf6702</Hash>
</Codenesium>*/