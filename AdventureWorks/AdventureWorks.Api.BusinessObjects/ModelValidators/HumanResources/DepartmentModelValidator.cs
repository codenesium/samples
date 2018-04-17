using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class DepartmentModelValidator: AbstractDepartmentModelValidator, IDepartmentModelValidator
	{
		public DepartmentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(DepartmentModel model)
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, DepartmentModel model)
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9b5d15bc6642c37da8aad76c4cc9cb5d</Hash>
</Codenesium>*/