using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("BusinessEntityContact", Schema="Person")]
        public partial class BusinessEntityContact : AbstractEntity
        {
                public BusinessEntityContact()
                {
                }

                public virtual void SetProperties(
                        int businessEntityID,
                        int contactTypeID,
                        DateTime modifiedDate,
                        int personID,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("ContactTypeID")]
                public int ContactTypeID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PersonID")]
                public int PersonID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>324594bd616f9523abda6351797a1de2</Hash>
</Codenesium>*/