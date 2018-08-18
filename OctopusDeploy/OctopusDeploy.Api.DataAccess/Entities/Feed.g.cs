using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Feed", Schema="dbo")]
	public partial class Feed : AbstractEntity
	{
		public Feed()
		{
		}

		public virtual void SetProperties(
			string feedType,
			string feedUri,
			string id,
			string jSON,
			string name)
		{
			this.FeedType = feedType;
			this.FeedUri = feedUri;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		[MaxLength(50)]
		[Column("FeedType")]
		public string FeedType { get; private set; }

		[MaxLength(512)]
		[Column("FeedUri")]
		public string FeedUri { get; private set; }

		[Key]
		[MaxLength(210)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f94611073074fc4d6d1e8dcbc80a08dc</Hash>
</Codenesium>*/