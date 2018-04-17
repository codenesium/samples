using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class StudentModelValidator: AbstractStudentModelValidator, IStudentModelValidator
	{
		public StudentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(StudentModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.IsAdultRules();
			this.BirthdayRules();
			this.FamilyIdRules();
			this.StudioIdRules();
			this.SmsRemindersEnabledRules();
			this.EmailRemindersEnabledRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StudentModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.IsAdultRules();
			this.BirthdayRules();
			this.FamilyIdRules();
			this.StudioIdRules();
			this.SmsRemindersEnabledRules();
			this.EmailRemindersEnabledRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>877089d6137c6a3705b71aa4842a714b</Hash>
</Codenesium>*/