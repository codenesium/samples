using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiQuoteTweetServerRequestModelValidator : AbstractApiQuoteTweetServerRequestModelValidator, IApiQuoteTweetServerRequestModelValidator
	{
		public ApiQuoteTweetServerRequestModelValidator(IQuoteTweetRepository quoteTweetRepository)
			: base(quoteTweetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiQuoteTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.RetweeterUserIdRules();
			this.SourceTweetIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiQuoteTweetServerRequestModel model)
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
    <Hash>74806dee9a3a5954bddda1b284a29050</Hash>
</Codenesium>*/