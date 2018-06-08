using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("JobCandidate", Schema="HumanResources")]
        public partial class JobCandidate: AbstractEntity
        {
                public JobCandidate()
                {
                }

                public void SetProperties(
                        Nullable<int> businessEntityID,
                        int jobCandidateID,
                        DateTime modifiedDate,
                        string resume)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.JobCandidateID = jobCandidateID;
                        this.ModifiedDate = modifiedDate;
                        this.Resume = resume;
                }

                [Column("BusinessEntityID", TypeName="int")]
                public Nullable<int> BusinessEntityID { get; private set; }

                [Key]
                [Column("JobCandidateID", TypeName="int")]
                public int JobCandidateID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Resume", TypeName="xml(-1)")]
                public string Resume { get; private set; }
        }
}

/*<Codenesium>
    <Hash>23b9d34e58d635153b170cc54886539b</Hash>
</Codenesium>*/