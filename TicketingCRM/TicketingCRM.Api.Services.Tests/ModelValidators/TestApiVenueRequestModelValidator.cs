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
	[Trait("Table", "Venue")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVenueRequestModelValidatorTest
	{
		public ApiVenueRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Address1_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address1_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address2_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void Address2_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void AdminId_Create_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetAdmin(It.IsAny<int>())).Returns(Task.FromResult<Admin>(new Admin()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void AdminId_Create_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetAdmin(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);

			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void AdminId_Update_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetAdmin(It.IsAny<int>())).Returns(Task.FromResult<Admin>(new Admin()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void AdminId_Update_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetAdmin(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Facebook_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
		}

		[Fact]
		public async void Facebook_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void ProvinceId_Create_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Create_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);

			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Update_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Update_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void Website_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}

		[Fact]
		public async void Website_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>5c9c5ff20b3fedaae624ab98ce51bcc4</Hash>
</Codenesium>*/