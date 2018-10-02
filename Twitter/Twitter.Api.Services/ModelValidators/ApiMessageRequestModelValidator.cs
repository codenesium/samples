using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiMessageRequestModelValidator : AbstractApiMessageRequestModelValidator, IApiMessageRequestModelValidator
	{
		public ApiMessageRequestModelValidator(IMessageRepository messageRepository)
			: base(messageRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMessageRequestModel model)
		{
			this.ContentRules();
			this.SenderUserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessageRequestModel model)
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
    <Hash>1e0bf51b9ad20772faa07bd03a77a69a</Hash>
</Codenesium>*/