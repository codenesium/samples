using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class TeacherModelValidator: AbstractTeacherModelValidator, ITeacherModelValidator
	{
		public TeacherModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(TeacherModel model)
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.EmailRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, TeacherModel model)
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.EmailRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>75a0a07f96557ee488468a8e4cbe2c40</Hash>
</Codenesium>*/