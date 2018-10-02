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
	[Trait("Table", "Studio")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiStudioRequestModelValidatorTest
	{
		public ApiStudioRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Address1_Create_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Update_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, null as string);
		}

		[Fact]
		public async void Address1_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address1_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address1, new string('A', 129));
		}

		[Fact]
		public async void Address2_Create_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
		}

		[Fact]
		public async void Address2_Update_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, null as string);
		}

		[Fact]
		public async void Address2_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void Address2_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Address2, new string('A', 129));
		}

		[Fact]
		public async void City_Create_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, null as string);
		}

		[Fact]
		public async void City_Update_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, null as string);
		}

		[Fact]
		public async void City_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 129));
		}

		[Fact]
		public async void City_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.City, new string('A', 129));
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Province_Create_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Province, null as string);
		}

		[Fact]
		public async void Province_Update_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Province, null as string);
		}

		[Fact]
		public async void Province_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Province, new string('A', 91));
		}

		[Fact]
		public async void Province_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Province, new string('A', 91));
		}

		[Fact]
		public async void Website_Create_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
		}

		[Fact]
		public async void Website_Update_null()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, null as string);
		}

		[Fact]
		public async void Website_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}

		[Fact]
		public async void Website_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 129));
		}

		[Fact]
		public async void Zip_Create_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Zip, new string('A', 129));
		}

		[Fact]
		public async void Zip_Update_length()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Zip, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>67b7014b2e4e5667b37b12af9a1e37ec</Hash>
</Codenesium>*/