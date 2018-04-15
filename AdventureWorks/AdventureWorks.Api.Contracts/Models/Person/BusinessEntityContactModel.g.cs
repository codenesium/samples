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

		public BusinessEntityContactModel(
			int personID,
			int contactTypeID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.PersonID = personID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int personID;

		[Required]
		public int PersonID
		{
			get
			{
				return this.personID;
			}

			set
			{
				this.personID = value;
			}
		}

		private int contactTypeID;

		[Required]
		public int ContactTypeID
		{
			get
			{
				return this.contactTypeID;
			}

			set
			{
				this.contactTypeID = value;
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
    <Hash>aa9509092917f6f003c51f8d5a88f9de</Hash>
</Codenesium>*/