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

                [JsonProperty]
                public int FamilyId { get; private set; }

                [JsonProperty]
                public int StudentId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>93d1b906c1c9c12bb313086f6c5aeda6</Hash>
</Codenesium>*/