using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("EmailAddress", Schema="Person")]
        public partial class EmailAddress: AbstractEntity
        {
                public EmailAddress()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        string emailAddress1,
                        int emailAddressID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EmailAddress1 = emailAddress1;
                        this.EmailAddressID = emailAddressID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [Key]
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("EmailAddress", TypeName="nvarchar(50)")]
                public string EmailAddress1 { get; private set; }

                [Column("EmailAddressID", TypeName="int")]
                public int EmailAddressID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a04a1ceb1ea10688daadbc7f35629fb8</Hash>
</Codenesium>*/