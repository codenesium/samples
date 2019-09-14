using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventStatusServerRequestModelValidatorTest
	{
		public ApiEventStatusServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusServerRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusServerRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusServerRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusServerRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>e48fd184bb65e2585eb1fada853cb2f9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/