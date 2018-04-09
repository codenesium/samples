using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityModelValidator: AbstractBusinessEntityModelValidator,IBusinessEntityModelValidator
	{
		public BusinessEntityModelValidator()
		{   }

		public void CreateMode()
		{
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>7ca162f439fc612ae3c62a5109780a56</Hash>
</Codenesium>*/