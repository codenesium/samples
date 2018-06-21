using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("Link", Schema="dbo")]
        public partial class Link : AbstractEntity
        {
                public Link()
                {
                }

                public void SetProperties(
                        Nullable<int> assignedMachineId,
                        int chainId,
                        Nullable<DateTime> dateCompleted,
                        Nullable<DateTime> dateStarted,
                        string dynamicParameters,
                        Guid externalId,
                        int id,
                        int linkStatusId,
                        string name,
                        int order,
                        string response,
                        string staticParameters,
                        int timeoutInSeconds)
                {
                        this.AssignedMachineId = assignedMachineId;
                        this.ChainId = chainId;
                        this.DateCompleted = dateCompleted;
                        this.DateStarted = dateStarted;
                        this.DynamicParameters = dynamicParameters;
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.LinkStatusId = linkStatusId;
                        this.Name = name;
                        this.Order = order;
                        this.Response = response;
                        this.StaticParameters = staticParameters;
                        this.TimeoutInSeconds = timeoutInSeconds;
                }

                [Column("assignedMachineId")]
                public Nullable<int> AssignedMachineId { get; private set; }

                [Column("chainId")]
                public int ChainId { get; private set; }

                [Column("dateCompleted")]
                public Nullable<DateTime> DateCompleted { get; private set; }

                [Column("dateStarted")]
                public Nullable<DateTime> DateStarted { get; private set; }

                [Column("dynamicParameters")]
                public string DynamicParameters { get; private set; }

                [Column("externalId")]
                public Guid ExternalId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("linkStatusId")]
                public int LinkStatusId { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("order")]
                public int Order { get; private set; }

                [Column("response")]
                public string Response { get; private set; }

                [Column("staticParameters")]
                public string StaticParameters { get; private set; }

                [Column("timeoutInSeconds")]
                public int TimeoutInSeconds { get; private set; }

                [ForeignKey("AssignedMachineId")]
                public virtual Machine Machine { get; set; }

                [ForeignKey("ChainId")]
                public virtual Chain Chain { get; set; }

                [ForeignKey("LinkStatusId")]
                public virtual LinkStatus LinkStatus { get; set; }
        }
}

/*<Codenesium>
    <Hash>049aa7d4ef0641d3cac4e5d7e7ef727f</Hash>
</Codenesium>*/