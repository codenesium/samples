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
	[Trait("Table", "EventStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventStatuServerRequestModelValidatorTest
	{
		public ApiEventStatuServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IEventStatuRepository> eventStatuRepository = new Mock<IEventStatuRepository>();
			eventStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatu()));

			var validator = new ApiEventStatuServerRequestModelValidator(eventStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IEventStatuRepository> eventStatuRepository = new Mock<IEventStatuRepository>();
			eventStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatu()));

			var validator = new ApiEventStatuServerRequestModelValidator(eventStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IEventStatuRepository> eventStatuRepository = new Mock<IEventStatuRepository>();
			eventStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatu()));

			var validator = new ApiEventStatuServerRequestModelValidator(eventStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IEventStatuRepository> eventStatuRepository = new Mock<IEventStatuRepository>();
			eventStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatu()));

			var validator = new ApiEventStatuServerRequestModelValidator(eventStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>9d421907a83ce1480f047331f386610f</Hash>
</Codenesium>*/