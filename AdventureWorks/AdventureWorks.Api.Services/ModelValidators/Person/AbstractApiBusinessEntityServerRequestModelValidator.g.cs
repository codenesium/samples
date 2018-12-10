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
	public abstract class AbstractApiBusinessEntityServerRequestModelValidator : AbstractValidator<ApiBusinessEntityServerRequestModel>
	{
		private int existingRecordId;

		protected IBusinessEntityRepository BusinessEntityRepository { get; private set; }

		public AbstractApiBusinessEntityServerRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
		{
			this.BusinessEntityRepository = businessEntityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiBusinessEntityServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByRowguid(ApiBusinessEntityServerRequestModel model,  CancellationToken cancellationToken)
		{
			BusinessEntity record = await this.BusinessEntityRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f341ba422b2cdeeac20eb589ff8beae0</Hash>
</Codenesium>*/