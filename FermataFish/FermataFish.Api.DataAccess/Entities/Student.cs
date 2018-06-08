using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Student", Schema="dbo")]
        public partial class Student: AbstractEntity
        {
                public Student()
                {
                }

                public void SetProperties(
                        DateTime birthday,
                        string email,
                        bool emailRemindersEnabled,
                        int familyId,
                        string firstName,
                        int id,
                        bool isAdult,
                        string lastName,
                        string phone,
                        bool smsRemindersEnabled,
                        int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.EmailRemindersEnabled = emailRemindersEnabled;
                        this.FamilyId = familyId;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.IsAdult = isAdult;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.SmsRemindersEnabled = smsRemindersEnabled;
                        this.StudioId = studioId;
                }

                [Column("birthday", TypeName="date")]
                public DateTime Birthday { get; private set; }

                [Column("email", TypeName="varchar(128)")]
                public string Email { get; private set; }

                [Column("emailRemindersEnabled", TypeName="bit")]
                public bool EmailRemindersEnabled { get; private set; }

                [Column("familyId", TypeName="int")]
                public int FamilyId { get; private set; }

                [Column("firstName", TypeName="varchar(128)")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("isAdult", TypeName="bit")]
                public bool IsAdult { get; private set; }

                [Column("lastName", TypeName="varchar(128)")]
                public string LastName { get; private set; }

                [Column("phone", TypeName="varchar(128)")]
                public string Phone { get; private set; }

                [Column("smsRemindersEnabled", TypeName="bit")]
                public bool SmsRemindersEnabled { get; private set; }

                [Column("studioId", TypeName="int")]
                public int StudioId { get; private set; }

                [ForeignKey("FamilyId")]
                public virtual Family Family { get; set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>383a4ab965ce80ccc5e9207f9b5d3825</Hash>
</Codenesium>*/