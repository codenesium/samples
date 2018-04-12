using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class DatabaseLogModelValidator: AbstractDatabaseLogModelValidator, IDatabaseLogModelValidator
	{
		public DatabaseLogModelValidator()
		{   }

		public void CreateMode()
		{
			this.PostTimeRules();
			this.DatabaseUserRules();
			this.@EventRules();
			this.SchemaRules();
			this.@ObjectRules();
			this.TSQLRules();
			this.XmlEventRules();
		}

		public void UpdateMode()
		{
			this.PostTimeRules();
			this.DatabaseUserRules();
			this.@EventRules();
			this.SchemaRules();
			this.@ObjectRules();
			this.TSQLRules();
			this.XmlEventRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>7702196794e2b3b3c997eb6a4e673c69</Hash>
</Codenesium>*/