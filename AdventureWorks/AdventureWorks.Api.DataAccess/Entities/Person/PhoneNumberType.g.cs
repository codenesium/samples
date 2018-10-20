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
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[Key]
		[Column("PhoneNumberTypeID")]
		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>21480be6dd82d2f98a14ec48bc1b6ea6</Hash>
</Codenesium>*/