using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkStatuRequestModelValidator : AbstractApiLinkStatuRequestModelValidator, IApiLinkStatuRequestModelValidator
	{
		public ApiLinkStatuRequestModelValidator(ILinkStatuRepository linkStatuRepository)
			: base(linkStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6e47df81ce98eadc7d435e701400aedc</Hash>
</Codenesium>*/