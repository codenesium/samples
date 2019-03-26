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
			int phoneNumberTypeID,
			DateTime modifiedDate,
			string name)
		{
			this.PhoneNumberTypeID = phoneNumberTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
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
    <Hash>56075edd943f49a9a0d073e52c885212</Hash>
</Codenesium>*/