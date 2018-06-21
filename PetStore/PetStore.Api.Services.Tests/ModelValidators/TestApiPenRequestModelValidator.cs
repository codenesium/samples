using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pen")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPenRequestModelValidatorTest
        {
                public ApiPenRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
                        penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

                        var validator = new ApiPenRequestModelValidator(penRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPenRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
                        penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

                        var validator = new ApiPenRequestModelValidator(penRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPenRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
                        penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

                        var validator = new ApiPenRequestModelValidator(penRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPenRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
                        penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

                        var validator = new ApiPenRequestModelValidator(penRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPenRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IPenRepository> penRepository = new Mock<IPenRepository>();
                        penRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));

                        var validator = new ApiPenRequestModelValidator(penRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>ddeb6acf61485a1e51d81e2f81c9a654</Hash>
</Codenesium>*/