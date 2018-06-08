using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
        [Table("Link", Schema="dbo")]
        public partial class Link:AbstractEntity
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

                [Column("assignedMachineId", TypeName="int")]
                public Nullable<int> AssignedMachineId { get; private set; }

                [Column("chainId", TypeName="int")]
                public int ChainId { get; private set; }

                [Column("dateCompleted", TypeName="datetime")]
                public Nullable<DateTime> DateCompleted { get; private set; }

                [Column("dateStarted", TypeName="datetime")]
                public Nullable<DateTime> DateStarted { get; private set; }

                [Column("dynamicParameters", TypeName="text(2147483647)")]
                public string DynamicParameters { get; private set; }

                [Column("externalId", TypeName="uniqueidentifier")]
                public Guid ExternalId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("linkStatusId", TypeName="int")]
                public int LinkStatusId { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("order", TypeName="int")]
                public int Order { get; private set; }

                [Column("response", TypeName="text(2147483647)")]
                public string Response { get; private set; }

                [Column("staticParameters", TypeName="text(2147483647)")]
                public string StaticParameters { get; private set; }

                [Column("timeoutInSeconds", TypeName="int")]
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
    <Hash>d744833bd1ebde2f288b7532aa982666</Hash>
</Codenesium>*/