using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityModelValidator: AbstractBusinessEntityModelValidator, IBusinessEntityModelValidator
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
    <Hash>d74ab07106a933dc308320fd681f7435</Hash>
</Codenesium>*/