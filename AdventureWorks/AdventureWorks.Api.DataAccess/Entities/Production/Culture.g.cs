using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Culture", Schema="Production")]
	public partial class Culture : AbstractEntity
	{
		public Culture()
		{
		}

		public virtual void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Key]
		[MaxLength(6)]
		[Column("CultureID")]
		public virtual string CultureID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad43aae202defdf7dcb47705fd8f7be3</Hash>
</Codenesium>*/