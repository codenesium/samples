using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("SpaceXSpaceFeature", Schema="dbo")]
        public partial class SpaceXSpaceFeature: AbstractEntity
        {
                public SpaceXSpaceFeature()
                {
                }

                public void SetProperties(
                        int id,
                        int spaceFeatureId,
                        int spaceId)
                {
                        this.Id = id;
                        this.SpaceFeatureId = spaceFeatureId;
                        this.SpaceId = spaceId;
                }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("spaceFeatureId", TypeName="int")]
                public int SpaceFeatureId { get; private set; }

                [Column("spaceId", TypeName="int")]
                public int SpaceId { get; private set; }

                [ForeignKey("SpaceFeatureId")]
                public virtual SpaceFeature SpaceFeature { get; set; }

                [ForeignKey("SpaceId")]
                public virtual Space Space { get; set; }
        }
}

/*<Codenesium>
    <Hash>2ad0491fd42f80958f59a43c2ba3c3c4</Hash>
</Codenesium>*/