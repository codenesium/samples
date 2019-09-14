using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("Unit", Schema="dbo")]
	public partial class Unit : AbstractEntity
	{
		public Unit()
		{
		}

		public virtual void SetProperties(
			int id,
			string callSign)
		{
			this.Id = id;
			this.CallSign = callSign;
		}

		[MaxLength(128)]
		[Column("callSign")]
		public virtual string CallSign { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f56439788f9d28ee1f728a3d6139dbd3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/