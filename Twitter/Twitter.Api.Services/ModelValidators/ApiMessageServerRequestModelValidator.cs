using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiMessageServerRequestModelValidator : AbstractApiMessageServerRequestModelValidator, IApiMessageServerRequestModelValidator
	{
		public ApiMessageServerRequestModelValidator(IMessageRepository messageRepository)
			: base(messageRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMessageServerRequestModel model)
		{
			this.ContentRules();
			this.SenderUserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessageServerRequestModel model)
		{
			this.ContentRules();
			this.SenderUserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>21c39e8f096e08cc19bf9e9ed320303a</Hash>
</Codenesium>*/