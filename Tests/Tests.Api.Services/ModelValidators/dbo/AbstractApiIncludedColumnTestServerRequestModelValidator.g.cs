using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiIncludedColumnTestServerRequestModelValidator : AbstractValidator<ApiIncludedColumnTestServerRequestModel>
	{
		private int existingRecordId;

		private IIncludedColumnTestRepository includedColumnTestRepository;

		public AbstractApiIncludedColumnTestServerRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
		{
			this.includedColumnTestRepository = includedColumnTestRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiIncludedColumnTestServerRequestModel model, int id)
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
    <Hash>9b07deb4af3236a1c8df7c33e4c47894</Hash>
</Codenesium>*/