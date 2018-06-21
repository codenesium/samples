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
                public async void Address1_Delete()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
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
                public async void Address2_Delete()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
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
                public async void City_Delete()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
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
                public async void Name_Delete()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
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
                public async void Website_Delete()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Zip_Create_null()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        await validator.ValidateCreateAsync(new ApiStudioRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Zip, null as string);
                }

                [Fact]
                public async void Zip_Update_null()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiStudioRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Zip, null as string);
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

                [Fact]
                public async void Zip_Delete()
                {
                        Mock<IStudioRepository> studioRepository = new Mock<IStudioRepository>();
                        studioRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));

                        var validator = new ApiStudioRequestModelValidator(studioRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>38b6a7e9acceab89930f689dbbbf16d3</Hash>
</Codenesium>*/