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
	public abstract class AbstractApiIncludedColumnTestRequestModelValidator : AbstractValidator<ApiIncludedColumnTestRequestModel>
	{
		private int existingRecordId;

		private IIncludedColumnTestRepository includedColumnTestRepository;

		public AbstractApiIncludedColumnTestRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
		{
			this.includedColumnTestRepository = includedColumnTestRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiIncludedColumnTestRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void Name2Rules()
		{
			this.RuleFor(x => x.Name2).NotNull();
			this.RuleFor(x => x.Name2).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>e82a1c90867bf8ee79a98e7d3188286e</Hash>
</Codenesium>*/