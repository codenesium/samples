using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class UnitMeasureModelValidator: AbstractUnitMeasureModelValidator,IUnitMeasureModelValidator
	{
		public UnitMeasureModelValidator()
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
    <Hash>33d109d3e5c5be5b3cab3a97638f0494</Hash>
</Codenesium>*/