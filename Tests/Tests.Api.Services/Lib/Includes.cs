using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public class RouteConstants
	{public const string ColumnSameAsFKTables = "columnsameasfktables";
	 public const string CompositePrimaryKeys = "compositeprimarykeys";
	 public const string IncludedColumnTests = "includedcolumntests";
	 public const string People = "people";
	 public const string RowVersionChecks = "rowversionchecks";
	 public const string SelfReferences = "selfreferences";
	 public const string Tables = "tables";
	 public const string TestAllFieldTypes = "testallfieldtypes";
	 public const string TestAllFieldTypesNullables = "testallfieldtypesnullables";
	 public const string TimestampChecks = "timestampchecks";
	 public const string VPersons = "vpersons";
	 public const string SchemaAPersons = "schemaapersons";
	 public const string SchemaBPersons = "schemabpersons";
	 public const string PersonRefs = "personrefs";}

	public abstract class AbstractService
	{
	}

	public abstract class AbstractBusinessObject
	{
	}

	public static class ValidationResponseFactory<T>
	{
		public static CreateResponse<T> CreateResponse(T record)
		{
			return new CreateResponse<T>(record);
		}

		public static CreateResponse<T> CreateResponse(ValidationResult result)
		{
			var response = new CreateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static UpdateResponse<T> UpdateResponse(T record)
		{
			return new UpdateResponse<T>(record);
		}

		public static UpdateResponse<T> UpdateResponse(ValidationResult result)
		{
			var response = new UpdateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static ActionResponse ActionResponse(ValidationResult result)
		{
			var response = new ActionResponse();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8816723cc7ffbb9b811f9e824d5a2657</Hash>
</Codenesium>*/