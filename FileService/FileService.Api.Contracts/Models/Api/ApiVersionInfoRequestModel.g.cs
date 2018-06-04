using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiVersionInfoRequestModel: AbstractApiRequestModel
	{
		public ApiVersionInfoRequestModel() : base()
		{}

		public void SetProperties(
			Nullable<DateTime> appliedOn,
			string description)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description;
		}

		private Nullable<DateTime> appliedOn;

		public Nullable<DateTime> AppliedOn
		{
			get
			{
				return this.appliedOn.IsEmptyOrZeroOrNull() ? null : this.appliedOn;
			}

			set
			{
				this.appliedOn = value;
			}
		}

		private string description;

		public string Description
		{
			get
			{
				return this.description.IsEmptyOrZeroOrNull() ? null : this.description;
			}

			set
			{
				this.description = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6d9677c4e4d1800be278b7b4e075e2d1</Hash>
</Codenesium>*/