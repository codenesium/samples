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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>b32f27c5f12a784216cf854e61ac0d4d</Hash>
</Codenesium>*/