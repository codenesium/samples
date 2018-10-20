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
	public abstract class AbstractApiUserRequestModelValidator : AbstractValidator<ApiUserRequestModel>
	{
		private int existingRecordId;

		private IUserRepository userRepository;

		public AbstractApiUserRequestModelValidator(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).NotNull();
			this.RuleFor(x => x.Password).Length(0, 128);
		}

		public virtual void UsernameRules()
		{
			this.RuleFor(x => x.Username).NotNull();
			this.RuleFor(x => x.Username).Length(0, 128);
		}

		public virtual void IsDeletedRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2d0aca02c186e17943023ebb1ab1d56f</Hash>
</Codenesium>*/