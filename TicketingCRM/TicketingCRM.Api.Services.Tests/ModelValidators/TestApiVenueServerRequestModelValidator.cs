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
	public partial class ApiVenueServerRequestModelValidatorTest
	{
		public ApiVenueServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Address1_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address1_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address2_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
		}

		[Fact]
		public async void Address2_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
		}

		[Fact]
		public async void Address2_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void Address2_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void AdminId_Create_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.AdminByAdminId(It.IsAny<int>())).Returns(Task.FromResult<Admin>(new Admin()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void AdminId_Create_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.AdminByAdminId(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);

			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void AdminId_Update_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.AdminByAdminId(It.IsAny<int>())).Returns(Task.FromResult<Admin>(new Admin()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void AdminId_Update_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.AdminByAdminId(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AdminId, 1);
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Facebook_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, null as string);
		}

		[Fact]
		public async void Facebook_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, null as string);
		}

		[Fact]
		public async void Facebook_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
		}

		[Fact]
		public async void Facebook_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Facebook, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void ProvinceId_Create_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Create_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);

			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Update_Valid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void ProvinceId_Update_Invalid_Reference()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.ProvinceByProvinceId(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
		}

		[Fact]
		public async void Website_Create_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
		}

		[Fact]
		public async void Website_Update_null()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
		}

		[Fact]
		public async void Website_Create_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateCreateAsync(new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}

		[Fact]
		public async void Website_Update_length()
		{
			Mock<IVenueRepository> venueRepository = new Mock<IVenueRepository>();
			venueRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Venue()));

			var validator = new ApiVenueServerRequestModelValidator(venueRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVenueServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>3071d6679bd254f011d21c20f2de929d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/