using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiUnitServerRequestModelValidator : AbstractValidator<ApiUnitServerRequestModel>
	{
		private int existingRecordId;

		protected IUnitRepository UnitRepository { get; private set; }

		public AbstractApiUnitServerRequestModelValidator(IUnitRepository unitRepository)
		{
			this.UnitRepository = unitRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CallSignRules()
		{
			this.RuleFor(x => x.CallSign).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>0c01b18cb31834af7b94c35b12af84f8</Hash>
</Codenesium>*/