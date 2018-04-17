using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PersonModelValidator: AbstractPersonModelValidator, IPersonModelValidator
	{
		public PersonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PersonModel model)
		{
			this.PersonTypeRules();
			this.NameStyleRules();
			this.TitleRules();
			this.FirstNameRules();
			this.MiddleNameRules();
			this.LastNameRules();
			this.SuffixRules();
			this.EmailPromotionRules();
			this.AdditionalContactInfoRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PersonModel model)
		{
			this.PersonTypeRules();
			this.NameStyleRules();
			this.TitleRules();
			this.FirstNameRules();
			this.MiddleNameRules();
			this.LastNameRules();
			this.SuffixRules();
			this.EmailPromotionRules();
			this.AdditionalContactInfoRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>74ec82dc1927b246485b86340d4c2518</Hash>
</Codenesium>*/