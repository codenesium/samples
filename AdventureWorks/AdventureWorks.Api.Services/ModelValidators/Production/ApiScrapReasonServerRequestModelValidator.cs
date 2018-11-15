using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiScrapReasonServerRequestModelValidator : AbstractApiScrapReasonServerRequestModelValidator, IApiScrapReasonServerRequestModelValidator
	{
		public ApiScrapReasonServerRequestModelValidator(IScrapReasonRepository scrapReasonRepository)
			: base(scrapReasonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>79d375396a76dc31e44ba8058a633a75</Hash>
</Codenesium>*/