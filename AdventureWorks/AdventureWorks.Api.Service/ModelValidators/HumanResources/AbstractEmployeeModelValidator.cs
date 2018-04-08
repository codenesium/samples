using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractEmployeeModelValidator: AbstractValidator<EmployeeModel>
	{
		public new ValidationResult Validate(EmployeeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPersonRepository PersonRepository {get; set;}
		public virtual void NationalIDNumberRules()
		{
			RuleFor(x => x.NationalIDNumber).NotNull();
			RuleFor(x => x.NationalIDNumber).Length(0,15);
		}

		public virtual void LoginIDRules()
		{
			RuleFor(x => x.LoginID).NotNull();
			RuleFor(x => x.LoginID).Length(0,256);
		}

		public virtual void OrganizationNodeRules()
		{                       }

		public virtual void OrganizationLevelRules()
		{                       }

		public virtual void JobTitleRules()
		{
			RuleFor(x => x.JobTitle).NotNull();
			RuleFor(x => x.JobTitle).Length(0,50);
		}

		public virtual void BirthDateRules()
		{
			RuleFor(x => x.BirthDate).NotNull();
		}

		public virtual void MaritalStatusRules()
		{
			RuleFor(x => x.MaritalStatus).NotNull();
			RuleFor(x => x.MaritalStatus).Length(0,1);
		}

		public virtual void GenderRules()
		{
			RuleFor(x => x.Gender).NotNull();
			RuleFor(x => x.Gender).Length(0,1);
		}

		public virtual void HireDateRules()
		{
			RuleFor(x => x.HireDate).NotNull();
		}

		public virtual void SalariedFlagRules()
		{
			RuleFor(x => x.SalariedFlag).NotNull();
		}

		public virtual void VacationHoursRules()
		{
			RuleFor(x => x.VacationHours).NotNull();
		}

		public virtual void SickLeaveHoursRules()
		{
			RuleFor(x => x.SickLeaveHours).NotNull();
		}

		public virtual void CurrentFlagRules()
		{
			RuleFor(x => x.CurrentFlag).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidPerson(int id)
		{
			Response response = new Response();

			this.PersonRepository.GetById(id,response);
			return response.People.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>af6d524177b4aa5cdc1a9be02986029c</Hash>
</Codenesium>*/