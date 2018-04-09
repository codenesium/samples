using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PersonModelValidator: AbstractPersonModelValidator,IPersonModelValidator
	{
		public PersonModelValidator()
		{   }

		public void CreateMode()
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
		}

		public void UpdateMode()
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
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>449a4dd7cfd283ff22f452a93345d485</Hash>
</Codenesium>*/