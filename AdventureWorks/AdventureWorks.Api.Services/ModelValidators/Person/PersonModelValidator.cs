using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPersonRequestModelValidator: AbstractApiPersonRequestModelValidator, IApiPersonRequestModelValidator
	{
		public ApiPersonRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model)
		{
			this.AdditionalContactInfoRules();
			this.DemographicsRules();
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
			this.DemographicsRules();
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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>fd2920d1d93c11c1a4e2499c4ff06f56</Hash>
</Codenesium>*/