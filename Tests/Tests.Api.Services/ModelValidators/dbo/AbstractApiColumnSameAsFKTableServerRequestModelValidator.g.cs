using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiColumnSameAsFKTableServerRequestModelValidator : AbstractValidator<ApiColumnSameAsFKTableServerRequestModel>
	{
		private int existingRecordId;

		protected IColumnSameAsFKTableRepository ColumnSameAsFKTableRepository { get; private set; }

		public AbstractApiColumnSameAsFKTableServerRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
		{
			this.ColumnSameAsFKTableRepository = columnSameAsFKTableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiColumnSameAsFKTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonRules()
		{
		}

		public virtual void PersonIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6d954e7043b8d31cbcee031c70fcc800</Hash>
</Codenesium>*/