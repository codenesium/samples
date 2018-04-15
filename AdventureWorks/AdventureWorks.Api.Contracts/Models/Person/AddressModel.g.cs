using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class AddressModel
	{
		public AddressModel()
		{}

		public AddressModel(
			string addressLine1,
			string addressLine2,
			string city,
			int stateProvinceID,
			string postalCode,
			object spatialLocation,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.AddressLine1 = addressLine1.ToString();
			this.AddressLine2 = addressLine2.ToString();
			this.City = city.ToString();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.PostalCode = postalCode.ToString();
			this.SpatialLocation = spatialLocation;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string addressLine1;

		[Required]
		public string AddressLine1
		{
			get
			{
				return this.addressLine1;
			}

			set
			{
				this.addressLine1 = value;
			}
		}

		private string addressLine2;

		public string AddressLine2
		{
			get
			{
				return this.addressLine2.IsEmptyOrZeroOrNull() ? null : this.addressLine2;
			}

			set
			{
				this.addressLine2 = value;
			}
		}

		private string city;

		[Required]
		public string City
		{
			get
			{
				return this.city;
			}

			set
			{
				this.city = value;
			}
		}

		private int stateProvinceID;

		[Required]
		public int StateProvinceID
		{
			get
			{
				return this.stateProvinceID;
			}

			set
			{
				this.stateProvinceID = value;
			}
		}

		private string postalCode;

		[Required]
		public string PostalCode
		{
			get
			{
				return this.postalCode;
			}

			set
			{
				this.postalCode = value;
			}
		}

		private object spatialLocation;

		public object SpatialLocation
		{
			get
			{
				return this.spatialLocation.IsEmptyOrZeroOrNull() ? null : this.spatialLocation;
			}

			set
			{
				this.spatialLocation = value;
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
    <Hash>5e90647f51a4495b410ba585a258c1ba</Hash>
</Codenesium>*/