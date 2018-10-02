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
	public partial class ApiEventStatusRequestModelValidatorTest
	{
		public ApiEventStatusRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IEventStatusRepository> eventStatusRepository = new Mock<IEventStatusRepository>();
			eventStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatus()));

			var validator = new ApiEventStatusRequestModelValidator(eventStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStatusRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>d7c5b7c28020b8c8d7707626319d16c5</Hash>
</Codenesium>*/