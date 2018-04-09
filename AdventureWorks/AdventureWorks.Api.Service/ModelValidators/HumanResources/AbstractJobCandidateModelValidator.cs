using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public IEmployeeRepository EmployeeRepository {get; set;}
		public virtual void BusinessEntityIDRules()
		{
			RuleFor(x => x.BusinessEntityID).Must(BeValidEmployee).When(x => x ?.BusinessEntityID != null).WithMessage("Invalid reference");
		}

		public virtual void ResumeRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidEmployee(Nullable<int> id)
		{
			return this.EmployeeRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>9a2cfea6c0200854b70b0ef94276bc61</Hash>
</Codenesium>*/