using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ContactType", Schema="Person")]
        public partial class ContactType : AbstractEntity
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
                [Column("ContactTypeID")]
                public int ContactTypeID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>384ae412547e887cd8a5c4f2126478e4</Hash>
</Codenesium>*/