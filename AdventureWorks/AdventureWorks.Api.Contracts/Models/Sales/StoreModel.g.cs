using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class StoreModel
	{
		public StoreModel()
		{}

		public StoreModel(
			string demographics,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			Nullable<int> salesPersonID)
		{
			this.Demographics = demographics;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.SalesPersonID = salesPersonID.ToNullableInt();
		}

		private string demographics;

		public string Demographics
		{
			get
			{
				return this.demographics.IsEmptyOrZeroOrNull() ? null : this.demographics;
			}

			set
			{
				this.demographics = value;
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

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
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

		private Nullable<int> salesPersonID;

		public Nullable<int> SalesPersonID
		{
			get
			{
				return this.salesPersonID.IsEmptyOrZeroOrNull() ? null : this.salesPersonID;
			}

			set
			{
				this.salesPersonID = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3d0f452b46e52638544cf8a5c961cad9</Hash>
</Codenesium>*/