using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiTagRequestModelValidator : AbstractApiTagRequestModelValidator, IApiTagRequestModelValidator
	{
		public ApiTagRequestModelValidator(ITagRepository tagRepository)
			: base(tagRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTagRequestModel model)
		{
			this.CountRules();
			this.ExcerptPostIdRules();
			this.TagNameRules();
			this.WikiPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagRequestModel model)
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
    <Hash>de4cca2432f476fb9e686694a4b18e74</Hash>
</Codenesium>*/