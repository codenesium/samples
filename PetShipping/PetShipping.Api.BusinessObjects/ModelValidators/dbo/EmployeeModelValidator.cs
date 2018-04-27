using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class EmployeeModelValidator: AbstractEmployeeModelValidator, IEmployeeModelValidator
	{
		public EmployeeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(EmployeeModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2ef4399a8bbac14445434c0945099b07</Hash>
</Codenesium>*/