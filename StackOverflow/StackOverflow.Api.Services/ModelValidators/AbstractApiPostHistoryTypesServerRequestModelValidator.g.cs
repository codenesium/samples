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
	public abstract class AbstractApiPostHistoryTypesServerRequestModelValidator : AbstractValidator<ApiPostHistoryTypesServerRequestModel>
	{
		private int existingRecordId;

		protected IPostHistoryTypesRepository PostHistoryTypesRepository { get; private set; }

		public AbstractApiPostHistoryTypesServerRequestModelValidator(IPostHistoryTypesRepository postHistoryTypesRepository)
		{
			this.PostHistoryTypesRepository = postHistoryTypesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypesServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void RwTypeRules()
		{
			this.RuleFor(x => x.RwType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RwType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>727cf27287d067d466edcf285bc72f60</Hash>
</Codenesium>*/