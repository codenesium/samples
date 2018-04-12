using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class PersonModelValidator: AbstractPersonModelValidator, IPersonModelValidator
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
    <Hash>911531159b3297659bbf255b874ce938</Hash>
</Codenesium>*/