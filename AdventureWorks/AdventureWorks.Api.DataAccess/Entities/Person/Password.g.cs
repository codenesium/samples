using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Password", Schema="Person")]
	public partial class Password : AbstractEntity
	{
		public Password()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			string passwordHash,
			string passwordSalt,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(128)]
		[Column("PasswordHash")]
		public virtual string PasswordHash { get; private set; }

		[MaxLength(10)]
		[Column("PasswordSalt")]
		public virtual string PasswordSalt { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual Person BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(Person item)
		{
			this.BusinessEntityIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>772aa6a2532db5c1885e3456d7f5a2b2</Hash>
</Codenesium>*/