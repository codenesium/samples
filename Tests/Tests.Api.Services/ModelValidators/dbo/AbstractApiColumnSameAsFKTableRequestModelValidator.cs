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
	public abstract class AbstractApiColumnSameAsFKTableRequestModelValidator : AbstractValidator<ApiColumnSameAsFKTableRequestModel>
	{
		private int existingRecordId;

		private IColumnSameAsFKTableRepository columnSameAsFKTableRepository;

		public AbstractApiColumnSameAsFKTableRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
		{
			this.columnSameAsFKTableRepository = columnSameAsFKTableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiColumnSameAsFKTableRequestModel model, int id)
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
    <Hash>ed20c2addac9f6d4e20e7b10712ec66c</Hash>
</Codenesium>*/