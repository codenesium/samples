using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class UnitMeasureModelValidator: AbstractUnitMeasureModelValidator, IUnitMeasureModelValidator
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
    <Hash>a6bd03c6f655626b49219e6c2fe57b27</Hash>
</Codenesium>*/