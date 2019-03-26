using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesReasonServerRequestModelValidator : AbstractValidator<ApiSalesReasonServerRequestModel>
	{
		private int existingRecordId;

		protected ISalesReasonRepository SalesReasonRepository { get; private set; }

		public AbstractApiSalesReasonServerRequestModelValidator(ISalesReasonRepository salesReasonRepository)
		{
			this.SalesReasonRepository = salesReasonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesReasonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ReasonTypeRules()
		{
			this.RuleFor(x => x.ReasonType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.ReasonType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>b05bd1ae02307a4df06880946e8208ae</Hash>
</Codenesium>*/