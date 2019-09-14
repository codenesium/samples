using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Space", Schema="dbo")]
	public partial class Space : AbstractEntity
	{
		public Space()
		{
		}

		public virtual void SetProperties(
			int id,
			string description,
			string name)
		{
			this.Id = id;
			this.Description = description;
			this.Name = name;
		}

		[MaxLength(128)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7f9ec6d083063a43163bec4c9895ec5e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/