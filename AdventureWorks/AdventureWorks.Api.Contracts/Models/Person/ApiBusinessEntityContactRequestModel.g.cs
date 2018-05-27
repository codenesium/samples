using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityContactRequestModel: AbstractApiRequestModel
	{
		public ApiBusinessEntityContactRequestModel() : base()
		{}

		public void SetProperties(
			int contactTypeID,
			DateTime modifiedDate,
			int personID,
			Guid rowguid)
		{
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToInt();
			this.Rowguid = rowguid.ToGuid();
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
    <Hash>eafcd010edba3d74a9d432fddbf63589</Hash>
</Codenesium>*/