using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiFollowingServerRequestModelValidator : AbstractValidator<ApiFollowingServerRequestModel>, IApiFollowingServerRequestModelValidator
	{
		private int existingRecordId;

		protected IFollowingRepository FollowingRepository { get; private set; }

		public ApiFollowingServerRequestModelValidator(IFollowingRepository followingRepository)
		{
			this.FollowingRepository = followingRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFollowingServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFollowingServerRequestModel model)
		{
			this.DateFollowedRules();
			this.MutedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowingServerRequestModel model)
		{
			this.DateFollowedRules();
			this.MutedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void DateFollowedRules()
		{
		}

		public virtual void MutedRules()
		{
			this.RuleFor(x => x.Muted).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>275b6f9e1621bed248a15ad9a8ddbf73</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/