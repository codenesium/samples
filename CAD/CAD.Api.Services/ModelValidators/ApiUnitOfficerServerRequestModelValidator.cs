using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiUnitOfficerServerRequestModelValidator : AbstractApiUnitOfficerServerRequestModelValidator, IApiUnitOfficerServerRequestModelValidator
	{
		public ApiUnitOfficerServerRequestModelValidator(IUnitOfficerRepository unitOfficerRepository)
			: base(unitOfficerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>19053e3d297fcf487b862ddf8f1aff52</Hash>
</Codenesium>*/