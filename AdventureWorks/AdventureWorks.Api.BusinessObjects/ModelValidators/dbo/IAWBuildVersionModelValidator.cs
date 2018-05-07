using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IAWBuildVersionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(AWBuildVersionModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, AWBuildVersionModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f64271c9d158add771a8a3202ecc5c39</Hash>
</Codenesium>*/