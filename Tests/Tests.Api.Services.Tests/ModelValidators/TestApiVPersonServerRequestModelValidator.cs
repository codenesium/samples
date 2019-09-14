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
	public partial class ApiVPersonServerRequestModelValidatorTest
	{
		public ApiVPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PersonName_Create_null()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonServerRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiVPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Update_null()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonServerRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Create_length()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonServerRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiVPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}

		[Fact]
		public async void PersonName_Update_length()
		{
			Mock<IVPersonRepository> vPersonRepository = new Mock<IVPersonRepository>();
			vPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VPerson()));

			var validator = new ApiVPersonServerRequestModelValidator(vPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>c9f1791e013f262f8959311b7d9460f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/