using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiTagsServerRequestModelValidator : AbstractApiTagsServerRequestModelValidator, IApiTagsServerRequestModelValidator
	{
		public ApiTagsServerRequestModelValidator(ITagsRepository tagsRepository)
			: base(tagsRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTagsServerRequestModel model)
		{
			this.CountRules();
			this.ExcerptPostIdRules();
			this.TagNameRules();
			this.WikiPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagsServerRequestModel model)
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
    <Hash>b54ee2707b5ff18eb1f345fd98ac3956</Hash>
</Codenesium>*/