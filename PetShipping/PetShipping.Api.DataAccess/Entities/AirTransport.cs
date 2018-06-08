using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("AirTransport", Schema="dbo")]
        public partial class AirTransport: AbstractEntity
        {
                public AirTransport()
                {
                }

                public void SetProperties(
                        int airlineId,
                        string flightNumber,
                        int handlerId,
                        int id,
                        DateTime landDate,
                        int pipelineStepId,
                        DateTime takeoffDate)
                {
                        this.AirlineId = airlineId;
                        this.FlightNumber = flightNumber;
                        this.HandlerId = handlerId;
                        this.Id = id;
                        this.LandDate = landDate;
                        this.PipelineStepId = pipelineStepId;
                        this.TakeoffDate = takeoffDate;
                }

                [Key]
                [Column("airlineId", TypeName="int")]
                public int AirlineId { get; private set; }

                [Column("flightNumber", TypeName="varchar(12)")]
                public string FlightNumber { get; private set; }

                [Column("handlerId", TypeName="int")]
                public int HandlerId { get; private set; }

                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("landDate", TypeName="datetime")]
                public DateTime LandDate { get; private set; }

                [Column("pipelineStepId", TypeName="int")]
                public int PipelineStepId { get; private set; }

                [Column("takeoffDate", TypeName="datetime")]
                public DateTime TakeoffDate { get; private set; }

                [ForeignKey("HandlerId")]
                public virtual Handler Handler { get; set; }
        }
}

/*<Codenesium>
    <Hash>3bd9f38fa6582c2fdea39ff19d40e466</Hash>
</Codenesium>*/