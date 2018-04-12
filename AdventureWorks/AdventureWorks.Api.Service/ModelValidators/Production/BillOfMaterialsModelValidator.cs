using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class BillOfMaterialsModelValidator: AbstractBillOfMaterialsModelValidator, IBillOfMaterialsModelValidator
	{
		public BillOfMaterialsModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductAssemblyIDRules();
			this.ComponentIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.UnitMeasureCodeRules();
			this.BOMLevelRules();
			this.PerAssemblyQtyRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductAssemblyIDRules();
			this.ComponentIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.UnitMeasureCodeRules();
			this.BOMLevelRules();
			this.PerAssemblyQtyRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>feeb552bbd76138acaba8e0a478e092c</Hash>
</Codenesium>*/