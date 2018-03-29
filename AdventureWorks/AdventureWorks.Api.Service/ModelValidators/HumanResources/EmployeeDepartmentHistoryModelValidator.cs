using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class EmployeeDepartmentHistoryModelValidator: AbstractEmployeeDepartmentHistoryModelValidator,IEmployeeDepartmentHistoryModelValidator
	{
		public EmployeeDepartmentHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.DepartmentIDRules();
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DepartmentIDRules();
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.DepartmentIDRules();
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>ca836cab7e7fc1936b596e74365a8991</Hash>
</Codenesium>*/