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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>c60b98353ffdf071ba5d7ce459975da9</Hash>
</Codenesium>*/