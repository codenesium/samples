using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiTeacherRequestModelValidator : AbstractValidator<ApiTeacherRequestModel>
	{
		private int existingRecordId;

		private ITeacherRepository teacherRepository;

		public AbstractApiTeacherRequestModelValidator(ITeacherRepository teacherRepository)
		{
			this.teacherRepository = teacherRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BirthdayRules()
		{
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).Length(0, 128);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUser).When(x => x?.UserId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teacherRepository.GetUser(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>992287536066d76c97663ac99b01a6d2</Hash>
</Codenesium>*/