using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ContactType", Schema="Person")]
        public partial class ContactType: AbstractEntity
        {
                public ContactType()
                {
                }

                public void SetProperties(
                        int contactTypeID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("ContactTypeID", TypeName="int")]
                public int ContactTypeID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b39e59bc2bae277ca2b8065f3036e059</Hash>
</Codenesium>*/