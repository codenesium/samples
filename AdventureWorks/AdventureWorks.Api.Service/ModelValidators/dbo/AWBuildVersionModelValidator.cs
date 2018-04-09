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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>8e1fd49529323fac9b0161fddd3f5a7f</Hash>
</Codenesium>*/