using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiContactTypeRequestModelValidator : AbstractApiContactTypeRequestModelValidator, IApiContactTypeRequestModelValidator
	{
		public ApiContactTypeRequestModelValidator(IContactTypeRepository contactTypeRepository)
			: base(contactTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model)
		{
			this.ModifiedDateRules();
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
    <Hash>3e1ce75a7cb31070df1883ae6bb536ee</Hash>
</Codenesium>*/