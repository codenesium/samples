using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services

{
	public abstract class AbstractApiStateRequestModelValidator: AbstractValidator<ApiStateRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiStateRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStateRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 2);
		}
	}
}

/*<Codenesium>
    <Hash>9b1df784c7aec4e71e12add6d7dc0d92</Hash>
</Codenesium>*/