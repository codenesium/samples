using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractJobCandidateModelValidator: AbstractValidator<JobCandidateModel>
	{
		public new ValidationResult Validate(JobCandidateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(JobCandidateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void BusinessEntityIDRules()
		{
			this.RuleFor(x => x.BusinessEntityID).Must(this.BeValidEmployee).When(x => x ?.BusinessEntityID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ResumeRules()
		{                       }

		private bool BeValidEmployee(Nullable<int> id)
		{
			return this.EmployeeRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>10d018e2ebe289b2d73154565d3d20c2</Hash>
</Codenesium>*/