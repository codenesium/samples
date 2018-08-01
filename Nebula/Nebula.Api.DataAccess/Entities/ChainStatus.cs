using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("ChainStatus", Schema="dbo")]
	public partial class ChainStatus : AbstractEntity
	{
		public ChainStatus()
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
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>91f03e669a7a2f3af9cebee0e16736b7</Hash>
</Codenesium>*/