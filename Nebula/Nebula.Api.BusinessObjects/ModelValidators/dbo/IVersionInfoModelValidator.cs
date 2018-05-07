using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IVersionInfoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(VersionInfoModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, VersionInfoModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>8bd5f7ba784cde7297fb3437efc81da9</Hash>
</Codenesium>*/