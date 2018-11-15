using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostLinkServerRequestModelValidator : AbstractApiPostLinkServerRequestModelValidator, IApiPostLinkServerRequestModelValidator
	{
		public ApiPostLinkServerRequestModelValidator(IPostLinkRepository postLinkRepository)
			: base(postLinkRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostLinkServerRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinkServerRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>af6c77d2254da462280a560317bb9515</Hash>
</Codenesium>*/