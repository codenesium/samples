using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductDescriptionModel
	{
		public ApiProductDescriptionModel()
		{}

		public ApiProductDescriptionModel(
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.Description = description.ToString();
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
    <Hash>5fe3e5c10884ad38435033d022dcdc3c</Hash>
</Codenesium>*/