using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiAdminServerRequestModelValidator : AbstractValidator<ApiAdminServerRequestModel>
	{
		private int existingRecordId;

		private IAdminRepository adminRepository;

		public AbstractApiAdminServerRequestModelValidator(IAdminRepository adminRepository)
		{
			this.adminRepository = adminRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAdminServerRequestModel model, int id)
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
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUserByUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.adminRepository.UserByUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>066978ccc859f5a2568c2bb2bd7701cb</Hash>
</Codenesium>*/