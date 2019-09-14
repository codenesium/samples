using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostTypeServerRequestModelValidator : AbstractValidator<ApiPostTypeServerRequestModel>, IApiPostTypeServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPostTypeRepository PostTypeRepository { get; private set; }

		public ApiPostTypeServerRequestModelValidator(IPostTypeRepository postTypeRepository)
		{
			this.PostTypeRepository = postTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostTypeServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypeServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void RwTypeRules()
		{
			this.RuleFor(x => x.RwType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RwType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>78baefeabb7658dcd3ef6042fe89e986</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/