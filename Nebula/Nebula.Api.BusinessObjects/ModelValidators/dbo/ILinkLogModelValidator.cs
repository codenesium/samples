using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkLogModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LinkLogModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LinkLogModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9f03d15143b9754a00416ded4c6445dc</Hash>
</Codenesium>*/