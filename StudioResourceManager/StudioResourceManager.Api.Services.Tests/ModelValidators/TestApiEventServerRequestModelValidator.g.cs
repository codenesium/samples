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
	[Trait("Table", "Event")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventServerRequestModelValidatorTest
	{
		public ApiEventServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EventStatusId_Create_Valid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatuByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatu>(new EventStatu()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventStatusId, 1);
		}

		[Fact]
		public async void EventStatusId_Create_Invalid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatuByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatu>(null));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventStatusId, 1);
		}

		[Fact]
		public async void EventStatusId_Update_Valid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatuByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatu>(new EventStatu()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventStatusId, 1);
		}

		[Fact]
		public async void EventStatusId_Update_Invalid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatuByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatu>(null));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>9a1848d10031a330e710d6a929318a6b</Hash>
</Codenesium>*/