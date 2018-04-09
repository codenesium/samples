using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesTerritoryHistoryModelValidator: AbstractSalesTerritoryHistoryModelValidator,ISalesTerritoryHistoryModelValidator
	{
		public SalesTerritoryHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>45d7338e694f7ce99eead25ade477e00</Hash>
</Codenesium>*/