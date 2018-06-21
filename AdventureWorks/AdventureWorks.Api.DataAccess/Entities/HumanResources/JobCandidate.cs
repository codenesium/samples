using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("JobCandidate", Schema="HumanResources")]
        public partial class JobCandidate : AbstractEntity
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

                [Column("BusinessEntityID")]
                public Nullable<int> BusinessEntityID { get; private set; }

                [Key]
                [Column("JobCandidateID")]
                public int JobCandidateID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Resume")]
                public string Resume { get; private set; }
        }
}

/*<Codenesium>
    <Hash>42a66af25273ba748b13a4b36830b675</Hash>
</Codenesium>*/