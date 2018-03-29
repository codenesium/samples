using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class DatabaseLogModelValidator: AbstractDatabaseLogModelValidator,IDatabaseLogModelValidator
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

		public void PatchMode()
		{
			this.PostTimeRules();
			this.DatabaseUserRules();
			this.@EventRules();
			this.SchemaRules();
			this.@ObjectRules();
			this.TSQLRules();
			this.XmlEventRules();
		}
	}
}

/*<Codenesium>
    <Hash>06254fcd06686791d95e54eae4ee9123</Hash>
</Codenesium>*/