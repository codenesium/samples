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
	public class ApiLinkTypeServerRequestModelValidator : AbstractValidator<ApiLinkTypeServerRequestModel>, IApiLinkTypeServerRequestModelValidator
	{
		private int existingRecordId;

		protected ILinkTypeRepository LinkTypeRepository { get; private set; }

		public ApiLinkTypeServerRequestModelValidator(ILinkTypeRepository linkTypeRepository)
		{
			this.LinkTypeRepository = linkTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkTypeServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypeServerRequestModel model)
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
    <Hash>e3d772fe92eca9b0b1cb27693a2593ee</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/