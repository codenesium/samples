using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostLinkRequestModelValidator : AbstractApiPostLinkRequestModelValidator, IApiPostLinkRequestModelValidator
	{
		public ApiPostLinkRequestModelValidator(IPostLinkRepository postLinkRepository)
			: base(postLinkRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostLinkRequestModel model)
		{
			this.CreationDateRules();
			this.LinkTypeIdRules();
			this.PostIdRules();
			this.RelatedPostIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinkRequestModel model)
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
    <Hash>b17d59bb8f4ca37571c598384e4413f8</Hash>
</Codenesium>*/