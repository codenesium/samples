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

		public void PatchMode()
		{
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>d26eae7d1b6a7b6f9ee492a4949b6131</Hash>
</Codenesium>*/