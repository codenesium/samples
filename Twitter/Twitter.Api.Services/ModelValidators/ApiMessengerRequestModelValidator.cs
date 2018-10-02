using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiMessengerRequestModelValidator : AbstractApiMessengerRequestModelValidator, IApiMessengerRequestModelValidator
	{
		public ApiMessengerRequestModelValidator(IMessengerRepository messengerRepository)
			: base(messengerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMessengerRequestModel model)
		{
			this.DateRules();
			this.FromUserIdRules();
			this.MessageIdRules();
			this.TimeRules();
			this.ToUserIdRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessengerRequestModel model)
		{
			this.DateRules();
			this.FromUserIdRules();
			this.MessageIdRules();
			this.TimeRules();
			this.ToUserIdRules();
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
    <Hash>44b8cc1726b0e3b1ffbc5829f98b20b8</Hash>
</Codenesium>*/