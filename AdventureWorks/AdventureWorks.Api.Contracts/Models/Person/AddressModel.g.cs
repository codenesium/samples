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
		public AddressModel(string addressLine1,
		                    string addressLine2,
		                    string city,
		                    int stateProvinceID,
		                    string postalCode,
		                    object spatialLocation,
		                    Guid rowguid,
		                    DateTime modifiedDate)
		{
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.StateProvinceID = stateProvinceID.ToInt();
			this.PostalCode = postalCode;
			this.SpatialLocation = spatialLocation;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _addressLine1;
		[Required]
		public string AddressLine1
		{
			get
			{
				return _addressLine1;
			}
			set
			{
				this._addressLine1 = value;
			}
		}

		private string _addressLine2;
		public string AddressLine2
		{
			get
			{
				return _addressLine2.IsEmptyOrZeroOrNull() ? null : _addressLine2;
			}
			set
			{
				this._addressLine2 = value;
			}
		}

		private string _city;
		[Required]
		public string City
		{
			get
			{
				return _city;
			}
			set
			{
				this._city = value;
			}
		}

		private int _stateProvinceID;
		[Required]
		public int StateProvinceID
		{
			get
			{
				return _stateProvinceID;
			}
			set
			{
				this._stateProvinceID = value;
			}
		}

		private string _postalCode;
		[Required]
		public string PostalCode
		{
			get
			{
				return _postalCode;
			}
			set
			{
				this._postalCode = value;
			}
		}

		private object _spatialLocation;
		public object SpatialLocation
		{
			get
			{
				return _spatialLocation.IsEmptyOrZeroOrNull() ? null : _spatialLocation;
			}
			set
			{
				this._spatialLocation = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e2bb625ca2c20d8b8a1fa11469b78bf2</Hash>
</Codenesium>*/