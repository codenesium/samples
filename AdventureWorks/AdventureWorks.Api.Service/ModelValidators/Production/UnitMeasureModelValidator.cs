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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>2e9463f8753a0eeff8dfb24ca55907d2</Hash>
</Codenesium>*/