using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class BusinessEntityContactModel
	{
		public BusinessEntityContactModel()
		{}
		public BusinessEntityContactModel(int personID,
		                                  int contactTypeID,
		                                  Guid rowguid,
		                                  DateTime modifiedDate)
		{
			this.PersonID = personID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int _personID;
		[Required]
		public int PersonID
		{
			get
			{
				return _personID;
			}
			set
			{
				this._personID = value;
			}
		}

		private int _contactTypeID;
		[Required]
		public int ContactTypeID
		{
			get
			{
				return _contactTypeID;
			}
			set
			{
				this._contactTypeID = value;
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
    <Hash>6000f494c57027fdd3d8a0bc4ab52e8b</Hash>
</Codenesium>*/