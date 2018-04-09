using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesOrderHeaderModelValidator
	{
		ValidationResult Validate(SalesOrderHeaderModel entity);

		Task<ValidationResult> ValidateAsync(SalesOrderHeaderModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>93211679457200bed739fdaf71f44331</Hash>
</Codenesium>*/