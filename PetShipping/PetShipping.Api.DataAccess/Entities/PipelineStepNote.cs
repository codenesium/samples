using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStepNote", Schema="dbo")]
        public partial class PipelineStepNote : AbstractEntity
        {
                public PipelineStepNote()
                {
                }

                public virtual void SetProperties(
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
                public virtual Employee EmployeeNavigation { get; private set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStepNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7f1654f6f2b05e3808253cacc3cc33c9</Hash>
</Codenesium>*/