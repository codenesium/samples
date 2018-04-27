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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PersonModel model)
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
    <Hash>f28f6ebdced36eeb8c70e15603238b36</Hash>
</Codenesium>*/