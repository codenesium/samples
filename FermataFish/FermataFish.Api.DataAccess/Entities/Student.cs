using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Student", Schema="dbo")]
        public partial class Student : AbstractEntity
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

                [Column("birthday")]
                public DateTime Birthday { get; private set; }

                [Column("email")]
                public string Email { get; private set; }

                [Column("emailRemindersEnabled")]
                public bool EmailRemindersEnabled { get; private set; }

                [Column("familyId")]
                public int FamilyId { get; private set; }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("isAdult")]
                public bool IsAdult { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }

                [Column("smsRemindersEnabled")]
                public bool SmsRemindersEnabled { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [ForeignKey("FamilyId")]
                public virtual Family Family { get; set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>2434cb76d89cc236e305e18a1987cbe1</Hash>
</Codenesium>*/