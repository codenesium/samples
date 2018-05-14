using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
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
    <Hash>d2b5f6f6e73fc12eb3c00a4870014a6b</Hash>
</Codenesium>*/