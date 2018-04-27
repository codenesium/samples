using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IVersionInfoModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(VersionInfoModel model);
		Task<ValidationResult>  ValidateUpdateAsync(long id, VersionInfoModel model);
		Task<ValidationResult>  ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>14214e03c7a648112ef1df166c2cf3ae</Hash>
</Codenesium>*/