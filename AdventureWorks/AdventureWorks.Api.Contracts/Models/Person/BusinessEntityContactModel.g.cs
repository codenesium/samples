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

		public BusinessEntityContactModel(POCOBusinessEntityContact poco)
		{
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.PersonID = poco.PersonID.Value.ToInt();
			this.ContactTypeID = poco.ContactTypeID.Value.ToInt();
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
    <Hash>55825a6891a89900d17d76f179583f28</Hash>
</Codenesium>*/