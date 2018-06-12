using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Feed", Schema="dbo")]
        public partial class Feed:AbstractEntity
        {
                public Feed()
                {
                }

                public void SetProperties(
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

                [Column("FeedType", TypeName="nvarchar(50)")]
                public string FeedType { get; private set; }

                [Column("FeedUri", TypeName="nvarchar(512)")]
                public string FeedUri { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(210)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8e318d32ba12114b9da96758b96132bb</Hash>
</Codenesium>*/