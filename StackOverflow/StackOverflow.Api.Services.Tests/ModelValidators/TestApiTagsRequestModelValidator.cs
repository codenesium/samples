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
        [Trait("Table", "Tags")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTagsRequestModelValidatorTest
        {
                public ApiTagsRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void TagName_Create_length()
                {
                        Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
                        tagsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));

                        var validator = new ApiTagsRequestModelValidator(tagsRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTagsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
                }

                [Fact]
                public async void TagName_Update_length()
                {
                        Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
                        tagsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));

                        var validator = new ApiTagsRequestModelValidator(tagsRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiTagsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
                }
        }
}

/*<Codenesium>
    <Hash>d4437dab3920f36abaf58ffc17ae48f3</Hash>
</Codenesium>*/