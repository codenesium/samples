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
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventTeacherRequestModelValidatorTest
	{
		public ApiEventTeacherRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EventId_Create_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.GetEvent(It.IsAny<int>())).Returns(Task.FromResult<Event>(new Event()));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Create_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.GetEvent(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Update_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.GetEvent(It.IsAny<int>())).Returns(Task.FromResult<Event>(new Event()));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Update_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.GetEvent(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>8b0dbc8cd401cda0c3db6c6a5fb8040b</Hash>
</Codenesium>*/