using FluentAssertions;
using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Area", "Includes")]
	public partial class ServiceIncludesTests
	{
		[Fact]
		public void Test_ValidationError()
		{
			var error = new ValidationError("1", "error", "field1");
			error.ErrorCode.Should().Be("1");
			error.ErrorMessage.Should().Be("error");
			error.PropertyName.Should().Be("field1");
		}

		[Fact]
		public void ActionResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			var response = ValidationResponseFactory<object>.ActionResponse(result);

			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void ActionResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			var result = new ValidationResult(failures);
			var response = ValidationResponseFactory<object>.ActionResponse(result);

			response.Success.Should().BeTrue();
		}

		[Fact]
		public void CreateResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			CreateResponse<int> response = ValidationResponseFactory<int>.CreateResponse(result);

			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void CreateResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);
			CreateResponse<int> response = ValidationResponseFactory<int>.CreateResponse(result);

			response.Success.Should().BeTrue();
		}

		[Fact]
		public void CreateResponse_SetRecord()
		{
			List<ValidationFailure> failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);

			var item = new
			{
				id = 1
			};

			CreateResponse<object> response = ValidationResponseFactory<object>.CreateResponse(result);

			response.SetRecord(item);
			response.Record.Should().NotBeNull();
		}

		[Fact]
		public void UpdateResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			UpdateResponse<int> response = ValidationResponseFactory<int>.UpdateResponse(result);

			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void UpdateResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);
			UpdateResponse<int> response = ValidationResponseFactory<int>.UpdateResponse(result);

			response.Success.Should().BeTrue();
		}

		[Fact]
		public void UpdateResponse_SetRecord()
		{
			List<ValidationFailure> failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);

			var item = new
			{
				id = 1
			};

			UpdateResponse<object> response = ValidationResponseFactory<object>.UpdateResponse(result);

			response.SetRecord(item);
			response.Record.Should().NotBeNull();
		}
	}
}

/*<Codenesium>
    <Hash>127e022a2d19f8c5120a1b3c0c3655c8</Hash>
</Codenesium>*/