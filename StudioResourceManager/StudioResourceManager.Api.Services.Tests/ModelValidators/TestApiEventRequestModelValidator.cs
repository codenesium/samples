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
	public partial class ApiEventRequestModelValidatorTest
	{
		public ApiEventRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= EventStatus
		[Fact]
		public async void EventStatusId_Create_Valid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatusByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatus>(new EventStatus()));

			var validator = new ApiEventRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventStatusId, 1);
		}

		[Fact]
		public async void EventStatusId_Create_Invalid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatusByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatus>(null));

			var validator = new ApiEventRequestModelValidator(eventRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventStatusId, 1);
		}

		[Fact]
		public async void EventStatusId_Update_Valid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatusByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatus>(new EventStatus()));

			var validator = new ApiEventRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventStatusId, 1);
		}

		[Fact]
		public async void EventStatusId_Update_Invalid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.EventStatusByEventStatusId(It.IsAny<int>())).Returns(Task.FromResult<EventStatus>(null));

			var validator = new ApiEventRequestModelValidator(eventRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>09a2d05a6a3c632fec6172d4c82374ba</Hash>
</Codenesium>*/