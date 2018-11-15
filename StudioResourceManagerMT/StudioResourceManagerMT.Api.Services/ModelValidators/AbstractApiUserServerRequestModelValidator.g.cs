using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiUserServerRequestModelValidator : AbstractValidator<ApiUserServerRequestModel>
	{
		private int existingRecordId;

		private IUserRepository userRepository;

		public AbstractApiUserServerRequestModelValidator(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserServerRequestModel model, int id)
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
	}
}

/*<Codenesium>
    <Hash>23b53e53336ba1f1fa22bcb1f29e4814</Hash>
</Codenesium>*/