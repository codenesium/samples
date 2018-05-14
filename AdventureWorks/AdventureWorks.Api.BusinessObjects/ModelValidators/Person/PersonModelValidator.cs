using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPersonModelValidator: AbstractApiPersonModelValidator, IApiPersonModelValidator
	{
		public ApiPersonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonModel model)
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

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c6001729e1f281938d2390482bfb9d13</Hash>
</Codenesium>*/