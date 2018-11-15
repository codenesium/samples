using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiMessengerServerRequestModelValidator : AbstractApiMessengerServerRequestModelValidator, IApiMessengerServerRequestModelValidator
	{
		public ApiMessengerServerRequestModelValidator(IMessengerRepository messengerRepository)
			: base(messengerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMessengerServerRequestModel model)
		{
			this.DateRules();
			this.FromUserIdRules();
			this.MessageIdRules();
			this.TimeRules();
			this.ToUserIdRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessengerServerRequestModel model)
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
    <Hash>b12523139f48cf83d33ca3b456e3d979</Hash>
</Codenesium>*/