using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Vendor", Schema="Purchasing")]
        public partial class Vendor : AbstractEntity
        {
                public Vendor()
                {
                }

                public virtual void SetProperties(
                        string accountNumber,
                        bool activeFlag,
                        int businessEntityID,
                        int creditRating,
                        DateTime modifiedDate,
                        string name,
                        bool preferredVendorStatus,
                        string purchasingWebServiceURL)
                {
                        this.AccountNumber = accountNumber;
                        this.ActiveFlag = activeFlag;
                        this.BusinessEntityID = businessEntityID;
                        this.CreditRating = creditRating;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PreferredVendorStatus = preferredVendorStatus;
                        this.PurchasingWebServiceURL = purchasingWebServiceURL;
                }

                [Column("AccountNumber")]
                public string AccountNumber { get; private set; }

                [Column("ActiveFlag")]
                public bool ActiveFlag { get; private set; }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("CreditRating")]
                public int CreditRating { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("PreferredVendorStatus")]
                public bool PreferredVendorStatus { get; private set; }

                [Column("PurchasingWebServiceURL")]
                public string PurchasingWebServiceURL { get; private set; }
        }
}

/*<Codenesium>
    <Hash>99306a22321d06a887d91508f79b09bc</Hash>
</Codenesium>*/