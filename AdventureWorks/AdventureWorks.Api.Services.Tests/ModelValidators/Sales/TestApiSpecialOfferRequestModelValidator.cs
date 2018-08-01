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
	public partial class ApiSpecialOfferRequestModelValidatorTest
	{
		public ApiSpecialOfferRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Category_Create_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
		}

		[Fact]
		public async void Category_Update_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, null as string);
		}

		[Fact]
		public async void Category_Create_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
		}

		[Fact]
		public async void Category_Update_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Category, new string('A', 51));
		}

		[Fact]
		public async void Description_Create_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Update_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, null as string);
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 256));
		}

		[Fact]
		public async void Type_Create_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Update_null()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, null as string);
		}

		[Fact]
		public async void Type_Create_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateCreateAsync(new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}

		[Fact]
		public async void Type_Update_length()
		{
			Mock<ISpecialOfferRepository> specialOfferRepository = new Mock<ISpecialOfferRepository>();
			specialOfferRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOffer()));

			var validator = new ApiSpecialOfferRequestModelValidator(specialOfferRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSpecialOfferRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>17d39266bfc9036d52cf78ab3ddafde2</Hash>
</Codenesium>*/