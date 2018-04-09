using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractEmployeePayHistoryModelValidator: AbstractValidator<EmployeePayHistoryModel>
	{
		public new ValidationResult Validate(EmployeePayHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeePayHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository {get; set;}
		public virtual void RateChangeDateRules()
		{
			RuleFor(x => x.RateChangeDate).NotNull();
		}

		public virtual void RateRules()
		{
			RuleFor(x => x.Rate).NotNull();
		}

		public virtual void PayFrequencyRules()
		{
			RuleFor(x => x.PayFrequency).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>edf1a5c489f587ba32af49072b9d4d76</Hash>
</Codenesium>*/