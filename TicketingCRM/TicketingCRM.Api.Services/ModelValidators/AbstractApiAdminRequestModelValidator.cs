using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiAdminRequestModelValidator : AbstractValidator<ApiAdminRequestModel>
	{
		private int existingRecordId;

		private IAdminRepository adminRepository;

		public AbstractApiAdminRequestModelValidator(IAdminRepository adminRepository)
		{
			this.adminRepository = adminRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAdminRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).Length(0, 128);
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).Length(0, 128);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).Length(0, 128);
		}

		public virtual void UsernameRules()
		{
			this.RuleFor(x => x.Username).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>75df52824af102bf2f3f91717091fa09</Hash>
</Codenesium>*/