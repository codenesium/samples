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
        }
}

/*<Codenesium>
    <Hash>a3d3b621852a67ee3ce1a26a67022083</Hash>
</Codenesium>*/