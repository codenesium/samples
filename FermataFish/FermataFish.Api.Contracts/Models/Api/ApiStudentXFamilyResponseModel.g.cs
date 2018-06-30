using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStudentXFamilyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int familyId,
                        int studentId)
                {
                        this.Id = id;
                        this.FamilyId = familyId;
                        this.StudentId = studentId;

                        this.FamilyIdEntity = nameof(ApiResponse.Families);
                        this.StudentIdEntity = nameof(ApiResponse.Students);
                }

                public int FamilyId { get; private set; }

                public string FamilyIdEntity { get; set; }

                public int Id { get; private set; }

                public int StudentId { get; private set; }

                public string StudentIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeFamilyIdValue { get; set; } = true;

                public bool ShouldSerializeFamilyId()
                {
                        return this.ShouldSerializeFamilyIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudentIdValue { get; set; } = true;

                public bool ShouldSerializeStudentId()
                {
                        return this.ShouldSerializeStudentIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeFamilyIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeStudentIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>cf8c51738048f30b4ad790826d97ed93</Hash>
</Codenesium>*/