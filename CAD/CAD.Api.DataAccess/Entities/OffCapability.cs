using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("OffCapability", Schema="dbo")]
	public partial class OffCapability : AbstractEntity
	{
		public OffCapability()
		{
		}

		public virtual void SetProperties(
			int id,
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1271bb213646c9ca2b187a4a3252c1c4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/