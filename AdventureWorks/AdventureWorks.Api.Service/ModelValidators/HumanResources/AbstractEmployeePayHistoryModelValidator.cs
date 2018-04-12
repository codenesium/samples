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

		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void RateChangeDateRules()
		{
			this.RuleFor(x => x.RateChangeDate).NotNull();
		}

		public virtual void RateRules()
		{
			this.RuleFor(x => x.Rate).NotNull();
		}

		public virtual void PayFrequencyRules()
		{
			this.RuleFor(x => x.PayFrequency).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>5281008510d02f344ba64d6d8f98d99f</Hash>
</Codenesium>*/