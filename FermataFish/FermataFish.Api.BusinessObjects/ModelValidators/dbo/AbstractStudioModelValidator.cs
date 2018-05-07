using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractStudioModelValidator: AbstractValidator<StudioModel>
	{
		public new ValidationResult Validate(StudioModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StudioModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStateRepository StateRepository { get; set; }
		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull();
			this.RuleFor(x => x.Address1).Length(0, 128);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).NotNull();
			this.RuleFor(x => x.Address2).Length(0, 128);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull();
			this.RuleFor(x => x.City).Length(0, 128);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void StateIdRules()
		{
			this.RuleFor(x => x.StateId).NotNull();
			this.RuleFor(x => x.StateId).Must(this.BeValidState).When(x => x ?.StateId != null).WithMessage("Invalid reference");
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull();
			this.RuleFor(x => x.Website).Length(0, 128);
		}

		public virtual void ZipRules()
		{
			this.RuleFor(x => x.Zip).NotNull();
			this.RuleFor(x => x.Zip).Length(0, 128);
		}

		private bool BeValidState(int id)
		{
			return this.StateRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>f99af04dd9f009a461a0dd4e1f2611f3</Hash>
</Codenesium>*/