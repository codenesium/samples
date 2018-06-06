using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services

{
	public abstract class AbstractApiOrganizationRequestModelValidator: AbstractValidator<ApiOrganizationRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiOrganizationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiOrganizationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>4891d429bb7ed7752cb1986d56557e8c</Hash>
</Codenesium>*/