using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("KeyAllocation", Schema="dbo")]
	public partial class KeyAllocation : AbstractEntity
	{
		public KeyAllocation()
		{
		}

		public virtual void SetProperties(
			int allocated,
			string collectionName)
		{
			this.Allocated = allocated;
			this.CollectionName = collectionName;
		}

		[Column("Allocated")]
		public int Allocated { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("CollectionName")]
		public string CollectionName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>57291d78394762ecab820c03cd4ac851</Hash>
</Codenesium>*/