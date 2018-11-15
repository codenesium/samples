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

		private ISalesReasonRepository salesReasonRepository;

		public AbstractApiSalesReasonServerRequestModelValidator(ISalesReasonRepository salesReasonRepository)
		{
			this.salesReasonRepository = salesReasonRepository;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ReasonTypeRules()
		{
			this.RuleFor(x => x.ReasonType).NotNull();
			this.RuleFor(x => x.ReasonType).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>a4b22c4d03c610f4b25cbf0097b83758</Hash>
</Codenesium>*/