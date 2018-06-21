using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PhoneNumberType", Schema="Person")]
        public partial class PhoneNumberType : AbstractEntity
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

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [Column("PhoneNumberTypeID")]
                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2d3e3c3792a583d54cac68712da99ad3</Hash>
</Codenesium>*/