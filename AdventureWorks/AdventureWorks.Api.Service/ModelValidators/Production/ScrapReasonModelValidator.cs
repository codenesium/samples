using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ScrapReasonModelValidator: AbstractScrapReasonModelValidator, IScrapReasonModelValidator
	{
		public ScrapReasonModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>3072cbdb652c83e6902a6d0c1f476c43</Hash>
</Codenesium>*/