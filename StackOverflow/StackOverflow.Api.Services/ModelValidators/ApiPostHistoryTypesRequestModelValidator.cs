using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public class ApiPostHistoryTypesRequestModelValidator : AbstractApiPostHistoryTypesRequestModelValidator, IApiPostHistoryTypesRequestModelValidator
        {
                public ApiPostHistoryTypesRequestModelValidator(IPostHistoryTypesRepository postHistoryTypesRepository)
                        : base(postHistoryTypesRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesRequestModel model)
                {
                        this.TypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesRequestModel model)
                {
                        this.TypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>e5a109d9a89af2f5aaa7eab01676fab8</Hash>
</Codenesium>*/