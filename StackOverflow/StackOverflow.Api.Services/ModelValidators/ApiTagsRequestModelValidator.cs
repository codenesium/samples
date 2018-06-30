using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public class ApiTagsRequestModelValidator : AbstractApiTagsRequestModelValidator, IApiTagsRequestModelValidator
        {
                public ApiTagsRequestModelValidator(ITagsRepository tagsRepository)
                        : base(tagsRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTagsRequestModel model)
                {
                        this.CountRules();
                        this.ExcerptPostIdRules();
                        this.TagNameRules();
                        this.WikiPostIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagsRequestModel model)
                {
                        this.CountRules();
                        this.ExcerptPostIdRules();
                        this.TagNameRules();
                        this.WikiPostIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>afdc73ae15a26b81eb87c93f9be3739c</Hash>
</Codenesium>*/