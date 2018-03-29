using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CurrencyModelValidator: AbstractCurrencyModelValidator,ICurrencyModelValidator
	{
		public CurrencyModelValidator()
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

		public void PatchMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>30561da7a42cc6d3f49146690ce6a3b0</Hash>
</Codenesium>*/