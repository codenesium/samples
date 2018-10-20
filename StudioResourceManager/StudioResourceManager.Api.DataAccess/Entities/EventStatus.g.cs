using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("EventStatus", Schema="dbo")]
	public partial class EventStatus : AbstractEntity
	{
		public EventStatus()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			bool isDeleted)
		{
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ac9ece5b91fc9c98c22c711642cd5ff0</Hash>
</Codenesium>*/