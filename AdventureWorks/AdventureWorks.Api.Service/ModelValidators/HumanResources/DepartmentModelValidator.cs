using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class DepartmentModelValidator: AbstractDepartmentModelValidator,IDepartmentModelValidator
	{
		public DepartmentModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>d4ff695a3237f4579fde6c32e60ae1f6</Hash>
</Codenesium>*/