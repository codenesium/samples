using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPersonRequestModelValidator : AbstractApiPersonRequestModelValidator, IApiPersonRequestModelValidator
	{
		public ApiPersonRequestModelValidator(IPersonRepository personRepository)
			: base(personRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model)
		{
			this.AdditionalContactInfoRules();
			this.DemographicRules();
			this.EmailPromotionRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.MiddleNameRules();
			this.ModifiedDateRules();
			this.NameStyleRules();
			this.PersonTypeRules();
			this.RowguidRules();
			this.SuffixRules();
			this.TitleRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model)
		{
			this.AdditionalContactInfoRules();
			this.DemographicRules();
			this.EmailPromotionRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.MiddleNameRules();
			this.ModifiedDateRules();
			this.NameStyleRules();
			this.PersonTypeRules();
			this.RowguidRules();
			this.SuffixRules();
			this.TitleRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5f87ee3b41a7a44e53fa218aa527bd63</Hash>
</Codenesium>*/