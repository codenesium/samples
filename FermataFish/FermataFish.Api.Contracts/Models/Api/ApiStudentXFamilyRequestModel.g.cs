using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>0178ef734524e80428b0868b5c2c6072</Hash>
</Codenesium>*/