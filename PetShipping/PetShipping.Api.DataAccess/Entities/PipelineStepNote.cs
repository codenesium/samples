using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStepNote", Schema="dbo")]
        public partial class PipelineStepNote : AbstractEntity
        {
                public PipelineStepNote()
                {
                }

                public void SetProperties(
                        int employeeId,
                        int id,
                        string note,
                        int pipelineStepId)
                {
                        this.EmployeeId = employeeId;
                        this.Id = id;
                        this.Note = note;
                        this.PipelineStepId = pipelineStepId;
                }

                [Column("employeeId")]
                public int EmployeeId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("note")]
                public string Note { get; private set; }

                [Column("pipelineStepId")]
                public int PipelineStepId { get; private set; }

                [ForeignKey("EmployeeId")]
                public virtual Employee Employee { get; set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>b9bcf893e82ffbd1ac110b639ed9c793</Hash>
</Codenesium>*/