using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("IncludedColumnTest", Schema="dbo")]
	public partial class IncludedColumnTest : AbstractEntity
	{
		public IncludedColumnTest()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			string name2)
		{
			this.Id = id;
			this.Name = name;
			this.Name2 = name2;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("name2")]
		public string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0d35dfc6178de80ff892fb15495128ce</Hash>
</Codenesium>*/