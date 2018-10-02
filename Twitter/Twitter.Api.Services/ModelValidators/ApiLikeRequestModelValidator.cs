using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiLikeRequestModelValidator : AbstractApiLikeRequestModelValidator, IApiLikeRequestModelValidator
	{
		public ApiLikeRequestModelValidator(ILikeRepository likeRepository)
			: base(likeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLikeRequestModel model)
		{
			this.LikerUserIdRules();
			this.TweetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLikeRequestModel model)
		{
			this.LikerUserIdRules();
			this.TweetIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>eb4697f5e0984cfc12aa462487e42a90</Hash>
</Codenesium>*/