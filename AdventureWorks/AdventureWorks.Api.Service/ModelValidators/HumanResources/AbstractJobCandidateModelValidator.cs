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

		public bool BeValidEmployee(Nullable<int> id)
		{
			Response response = new Response();

			this.EmployeeRepository.GetById(id.GetValueOrDefault(),response);
			return response.Employees.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>2b81631d799048c106052764942f3046</Hash>
</Codenesium>*/