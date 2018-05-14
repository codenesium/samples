using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineStatusModelValidator: AbstractValidator<ApiPipelineStatusModel>
	{
		public new ValidationResult Validate(ApiPipelineStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStatusModel model)
		{
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
    <Hash>6778e6bad30de86ef670fe9e85fa6e66</Hash>
</Codenesium>*/