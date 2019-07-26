using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bank.BusinessLogic.Entities
{
    [XmlRoot(ElementName = "TotalAmount")]
    public class TotalAmount : Identifier
    {
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }
    }

    [XmlRoot(ElementName = "ContractData")]
    public class ContractData : Identifier
    {
        [XmlElement(ElementName = "Branch")]
        public string Branch { get; set; }
        [XmlElement(ElementName = "PhaseOfContract")]
        public string PhaseOfContract { get; set; }
        [XmlElement(ElementName = "ContractStatus")]
        public string ContractStatus { get; set; }
        [XmlElement(ElementName = "TypeOfContract")]
        public string TypeOfContract { get; set; }
        [XmlElement(ElementName = "ContractSubtype")]
        public string ContractSubtype { get; set; }
        [XmlElement(ElementName = "OwnershipType")]
        public string OwnershipType { get; set; }
        [XmlElement(ElementName = "PurposeOfFinancing")]
        public string PurposeOfFinancing { get; set; }
        [XmlElement(ElementName = "CurrencyOfContract")]
        public string CurrencyOfContract { get; set; }
        [XmlElement(ElementName = "TotalAmount")]
        public TotalAmount TotalAmount { get; set; }
        [XmlElement(ElementName = "NextPaymentDate")]
        public string NextPaymentDate { get; set; }
        [XmlElement(ElementName = "TotalMonthlyPayment")]
        public TotalAmount TotalMonthlyPayment { get; set; }
        [XmlElement(ElementName = "PaymentPeriodicity")]
        public string PaymentPeriodicity { get; set; }
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "RestructuringDate")]
        public string RestructuringDate { get; set; }
        [XmlElement(ElementName = "ExpectedEndDate")]
        public string ExpectedEndDate { get; set; }
        [XmlElement(ElementName = "RealEndDate")]
        public string RealEndDate { get; set; }
        [XmlElement(ElementName = "NegativeStatusOfContract")]
        public string NegativeStatusOfContract { get; set; }
        [XmlElement(ElementName = "ProlongationAmount")]
        public TotalAmount ProlongationAmount { get; set; }
        [XmlElement(ElementName = "ProlongationDate")]
        public string ProlongationDate { get; set; }
    }

    [XmlRoot(ElementName = "SubjectRole")]
    public class SubjectRole : Identifier
    {
        [XmlElement(ElementName = "CustomerCode")]
        public string CustomerCode { get; set; }
        [XmlElement(ElementName = "RoleOfCustomer")]
        public string RoleOfCustomer { get; set; }
        [XmlElement(ElementName = "RealEndDate")]
        public string RealEndDate { get; set; }
        [XmlElement(ElementName = "GuarantorRelationship")]
        public string GuarantorRelationship { get; set; }
    }

    [XmlRoot(ElementName = "Contract")]
    public class Contract : Identifier
    {
        [XmlElement(ElementName = "ContractCode")]
        public string ContractCode { get; set; }
        [XmlElement(ElementName = "ContractData")]
        public ContractData ContractData { get; set; }
        [XmlElement(ElementName = "SubjectRole")]
        public List<SubjectRole> SubjectRole { get; set; }
    }

    [XmlRoot(ElementName = "Batch")]
    public class Batch : Identifier
    {
        public int CurentId { get; set; }
        [XmlElement(ElementName = "BatchIdentifier")]
        public string BatchIdentifier { get; set; }
        [XmlElement(ElementName = "Contract")]
        public Contract Contract { get; set; }
    }

    public class Identifier
    {
        [XmlIgnore]
        public int Id { get; set; }
    }
}