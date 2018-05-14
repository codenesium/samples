using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiVersionInfoModel
	{
		public ApiVersionInfoModel()
		{}

		public ApiVersionInfoModel(
			Nullable<DateTime> appliedOn,
			string description)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description.ToString();
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
    <Hash>56397bd049b28276a42f6f60af81191d</Hash>
</Codenesium>*/