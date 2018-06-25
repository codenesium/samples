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
        [Trait("Table", "State")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiStateRequestModelValidatorTest
        {
                public ApiStateRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);
                        await validator.ValidateCreateAsync(new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 3));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
                        stateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));

                        var validator = new ApiStateRequestModelValidator(stateRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiStateRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 3));
                }
        }
}

/*<Codenesium>
    <Hash>73f7ce4525477fdbac2004e72dc58ab6</Hash>
</Codenesium>*/