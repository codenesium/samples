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

		public void PatchMode()
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>c76eab772f6c035de6b921d33111e031</Hash>
</Codenesium>*/