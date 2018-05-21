using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiVersionInfoModel: AbstractModel
	{
		public ApiVersionInfoModel() : base()
		{}

		public ApiVersionInfoModel(
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
    <Hash>ab2478d14dc47a44a97261a08658a260</Hash>
</Codenesium>*/