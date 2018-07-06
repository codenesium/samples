using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStudentResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime birthday,
                        string email,
                        bool emailRemindersEnabled,
                        int familyId,
                        string firstName,
                        bool isAdult,
                        string lastName,
                        string phone,
                        bool smsRemindersEnabled,
                        int studioId)
                {
                        this.Id = id;
                        this.Birthday = birthday;
                        this.Email = email;
                        this.EmailRemindersEnabled = emailRemindersEnabled;
                        this.FamilyId = familyId;
                        this.FirstName = firstName;
                        this.IsAdult = isAdult;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.SmsRemindersEnabled = smsRemindersEnabled;
                        this.StudioId = studioId;

                        this.FamilyIdEntity = nameof(ApiResponse.Families);
                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public DateTime Birthday { get; private set; }

                public string Email { get; private set; }

                public bool EmailRemindersEnabled { get; private set; }

                public int FamilyId { get; private set; }

                public string FamilyIdEntity { get; set; }

                public string FirstName { get; private set; }

                public int Id { get; private set; }

                public bool IsAdult { get; private set; }

                public string LastName { get; private set; }

                public string Phone { get; private set; }

                public bool SmsRemindersEnabled { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>f431bc43ae377ca1214ec418cc40103f</Hash>
</Codenesium>*/