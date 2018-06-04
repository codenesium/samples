using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductDescriptionRequestModel: AbstractApiRequestModel
	{
		public ApiProductDescriptionRequestModel() : base()
		{}

		public void SetProperties(
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		private string description;

		[Required]
		public string Description
		{
			get
			{
				return this.description;
			}

			set
			{
				this.description = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>307ccf71e2002d5e1cc46de32ee0f940</Hash>
</Codenesium>*/