using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSpecialOfferServerRequestModelValidatorTest
	{
		public ApiSpecialOfferServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Category_Create_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
		}

		[Fact]
		public async void Category_Update_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
		}

		[Fact]
		public async void Category_Create_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
		}

		[Fact]
		public async void Category_Update_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SpecialOffer>(new SpecialOffer()));
			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);

			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SpecialOffer>(null));
			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);

			await validator.ValidateCreateAsync(new ApiSpecialOfferServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SpecialOffer>(new SpecialOffer()));
			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SpecialOffer>(null));
			var validator = new ApiSpecialOfferServerRequestModelValidator(specialOfferRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>1625519b9284ecf5a8f8d95ccdf57660</Hash>
</Codenesium>*/