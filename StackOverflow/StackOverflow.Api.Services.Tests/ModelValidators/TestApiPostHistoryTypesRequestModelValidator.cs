using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostHistoryTypes")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPostHistoryTypesRequestModelValidatorTest
        {
                public ApiPostHistoryTypesRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Type_Create_length()
                {
                        Mock<IPostHistoryTypesRepository> postHistoryTypesRepository = new Mock<IPostHistoryTypesRepository>();
                        postHistoryTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));

                        var validator = new ApiPostHistoryTypesRequestModelValidator(postHistoryTypesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiPostHistoryTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Update_length()
                {
                        Mock<IPostHistoryTypesRepository> postHistoryTypesRepository = new Mock<IPostHistoryTypesRepository>();
                        postHistoryTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));

                        var validator = new ApiPostHistoryTypesRequestModelValidator(postHistoryTypesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }
        }
}

/*<Codenesium>
    <Hash>eb94aeff70b9e5427a323b6f45fb79c3</Hash>
</Codenesium>*/