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
			string name,
			Nullable<int> salesPersonID,
			string demographics,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.Name = name;
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.Demographics = demographics;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>58e1eb0cd21ffa195de29e47e5f2d508</Hash>
</Codenesium>*/