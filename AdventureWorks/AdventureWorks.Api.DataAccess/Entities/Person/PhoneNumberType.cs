using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PhoneNumberType", Schema="Person")]
        public partial class PhoneNumberType: AbstractEntity
        {
                public PhoneNumberType()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        int phoneNumberTypeID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Key]
                [Column("PhoneNumberTypeID", TypeName="int")]
                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d0b6b09d57b9293740d8041067b5766b</Hash>
</Codenesium>*/