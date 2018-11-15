using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PhoneNumberType", Schema="Person")]
	public partial class PhoneNumberType : AbstractEntity
	{
		public PhoneNumberType()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			int phoneNumberTypeID)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.PhoneNumberTypeID = phoneNumberTypeID;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("PhoneNumberTypeID")]
		public virtual int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>96d0634b47713809b61d07e3e8b3df8b</Hash>
</Codenesium>*/