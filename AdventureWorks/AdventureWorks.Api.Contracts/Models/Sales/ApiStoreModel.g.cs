using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiStoreModel
	{
		public ApiStoreModel()
		{}

		public ApiStoreModel(
			string demographics,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			Nullable<int> salesPersonID)
		{
			this.Demographics = demographics;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
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
    <Hash>36ad0b3fb723603684d6b8f0da0e5eee</Hash>
</Codenesium>*/