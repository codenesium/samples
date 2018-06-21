using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public class ApiPostHistoryRequestModelValidator : AbstractApiPostHistoryRequestModelValidator, IApiPostHistoryRequestModelValidator
        {
                public ApiPostHistoryRequestModelValidator(IPostHistoryRepository postHistoryRepository)
                        : base(postHistoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryRequestModel model)
                {
                        this.CommentRules();
                        this.CreationDateRules();
                        this.PostHistoryTypeIdRules();
                        this.PostIdRules();
                        this.RevisionGUIDRules();
                        this.TextRules();
                        this.UserDisplayNameRules();
                        this.UserIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryRequestModel model)
                {
                        this.CommentRules();
                        this.CreationDateRules();
                        this.PostHistoryTypeIdRules();
                        this.PostIdRules();
                        this.RevisionGUIDRules();
                        this.TextRules();
                        this.UserDisplayNameRules();
                        this.UserIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>b7f77b68c550296f12873c3795f62695</Hash>
</Codenesium>*/