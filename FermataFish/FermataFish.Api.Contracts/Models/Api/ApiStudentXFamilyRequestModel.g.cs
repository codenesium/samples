using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStudentXFamilyRequestModel: AbstractApiRequestModel
        {
                public ApiStudentXFamilyRequestModel() : base()
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
    <Hash>86acdf0912b62f3d32deebec71a518f2</Hash>
</Codenesium>*/