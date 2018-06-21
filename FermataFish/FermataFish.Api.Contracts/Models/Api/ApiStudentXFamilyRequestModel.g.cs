using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStudentXFamilyRequestModel : AbstractApiRequestModel
        {
                public ApiStudentXFamilyRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        int familyId,
                        int studentId)
                {
                        this.FamilyId = familyId;
                        this.StudentId = studentId;
                }

                private int familyId;

                [Required]
                public int FamilyId
                {
                        get
                        {
                                return this.familyId;
                        }

                        set
                        {
                                this.familyId = value;
                        }
                }

                private int studentId;

                [Required]
                public int StudentId
                {
                        get
                        {
                                return this.studentId;
                        }

                        set
                        {
                                this.studentId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a2c99733897402a89d164468eb3e5f0f</Hash>
</Codenesium>*/