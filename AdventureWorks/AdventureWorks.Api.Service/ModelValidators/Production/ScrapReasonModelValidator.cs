using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ScrapReasonModelValidator: AbstractScrapReasonModelValidator,IScrapReasonModelValidator
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
    <Hash>7016fe50223c05ac68f3488f2034d463</Hash>
</Codenesium>*/