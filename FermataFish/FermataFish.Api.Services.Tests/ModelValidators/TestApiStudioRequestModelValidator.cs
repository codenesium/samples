using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
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
		public async void StateId_Create_Valid_Reference()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.GetState(It.IsAny<int>())).Returns(Task.FromResult<State>(new State()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StateId, 1);
		}

		[Fact]
		public async void StateId_Create_Invalid_Reference()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.GetState(It.IsAny<int>())).Returns(Task.FromResult<State>(null));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateId, 1);
		}

		[Fact]
		public async void StateId_Update_Valid_Reference()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.GetState(It.IsAny<int>())).Returns(Task.FromResult<State>(new State()));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StateId, 1);
		}

		[Fact]
		public async void StateId_Update_Invalid_Reference()
		{
			Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
			studioRepository.Setup(x => x.GetState(It.IsAny<int>())).Returns(Task.FromResult<State>(null));

			var validator = new ApiStudioRequestModelValidator(studioRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StateId, 1);
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
    <Hash>3ce6c4d6a25a2d15ae3c1761657d623a</Hash>
</Codenesium>*/