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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>2d8ad3c5cd7497b104e3ecff5331e0d7</Hash>
</Codenesium>*/