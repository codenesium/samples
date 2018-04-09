using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class BillOfMaterialsModelValidator: AbstractBillOfMaterialsModelValidator,IBillOfMaterialsModelValidator
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
    <Hash>4b5830257fbc07b0b6647f779bf1943f</Hash>
</Codenesium>*/