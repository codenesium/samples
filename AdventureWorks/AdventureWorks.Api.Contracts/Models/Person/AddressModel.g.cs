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
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			object spatialLocation,
			int stateProvinceID)
		{
			this.AddressLine1 = addressLine1.ToString();
			this.AddressLine2 = addressLine2.ToString();
			this.City = city.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PostalCode = postalCode.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.SpatialLocation = spatialLocation;
			this.StateProvinceID = stateProvinceID.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>0d80f89c72f72ab8c663a819a750dc3c</Hash>
</Codenesium>*/