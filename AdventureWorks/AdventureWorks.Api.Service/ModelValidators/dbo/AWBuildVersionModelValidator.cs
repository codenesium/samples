using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class AWBuildVersionModelValidator: AbstractAWBuildVersionModelValidator,IAWBuildVersionModelValidator
	{
		public AWBuildVersionModelValidator()
		{   }

		public void CreateMode()
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>73cef90bc45ce73c60684af44ccbae0d</Hash>
</Codenesium>*/