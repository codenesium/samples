using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CultureModelValidator: AbstractCultureModelValidator,ICultureModelValidator
	{
		public CultureModelValidator()
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
    <Hash>65ee3404dc919ed9f449821ef88760a5</Hash>
</Codenesium>*/