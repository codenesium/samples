using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiQuoteTweetRequestModelValidator : AbstractApiQuoteTweetRequestModelValidator, IApiQuoteTweetRequestModelValidator
	{
		public ApiQuoteTweetRequestModelValidator(IQuoteTweetRepository quoteTweetRepository)
			: base(quoteTweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiQuoteTweetRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.RetweeterUserIdRules();
			this.SourceTweetIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiQuoteTweetRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.RetweeterUserIdRules();
			this.SourceTweetIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c58058dd91098a13516043331f04a1f3</Hash>
</Codenesium>*/