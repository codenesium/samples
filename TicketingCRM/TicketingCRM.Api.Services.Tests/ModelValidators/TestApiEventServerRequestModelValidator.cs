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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
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
		public async void Address1_Create_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Update_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Create_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address1_Update_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address2_Create_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
		}

		[Fact]
		public async void Address2_Update_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
		}

		[Fact]
		public async void Address2_Create_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void Address2_Update_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void CityId_Create_Valid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.CityByCityId(It.IsAny<int>())).Returns(Task.FromResult<City>(new City()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CityId, 1);
		}

		[Fact]
		public async void CityId_Create_Invalid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.CityByCityId(It.IsAny<int>())).Returns(Task.FromResult<City>(null));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CityId, 1);
		}

		[Fact]
		public async void CityId_Update_Valid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.CityByCityId(It.IsAny<int>())).Returns(Task.FromResult<City>(new City()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CityId, 1);
		}

		[Fact]
		public async void CityId_Update_Invalid_Reference()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.CityByCityId(It.IsAny<int>())).Returns(Task.FromResult<City>(null));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CityId, 1);
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Facebook_Create_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, null as string);
		}

		[Fact]
		public async void Facebook_Update_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, null as string);
		}

		[Fact]
		public async void Facebook_Create_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
		}

		[Fact]
		public async void Facebook_Update_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Website_Create_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
		}

		[Fact]
		public async void Website_Update_null()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
		}

		[Fact]
		public async void Website_Create_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}

		[Fact]
		public async void Website_Update_length()
		{
			Mock<IEventRepository> eventRepository = new Mock<IEventRepository>();
			eventRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));

			var validator = new ApiEventServerRequestModelValidator(eventRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>2e6dc58564fb6f2bf46c25d34e078a75</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/