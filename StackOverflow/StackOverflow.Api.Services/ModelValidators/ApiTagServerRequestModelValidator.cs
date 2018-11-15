using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiTagServerRequestModelValidator : AbstractApiTagServerRequestModelValidator, IApiTagServerRequestModelValidator
	{
		public ApiTagServerRequestModelValidator(ITagRepository tagRepository)
			: base(tagRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTagServerRequestModel model)
		{
			this.CountRules();
			this.ExcerptPostIdRules();
			this.TagNameRules();
			this.WikiPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagServerRequestModel model)
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
    <Hash>449e51153d08dd7d1459da528fd20459</Hash>
</Codenesium>*/