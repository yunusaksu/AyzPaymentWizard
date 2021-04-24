using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzPaymentWizard.Model
{
    [FixedLengthRecord(FixedMode.ExactLength)]
    public class RecordDetails
    {
        [FieldFixedLength(1)]
        public string Dstring { get; set; }
        [FieldFixedLength(4)]

        [FieldAlign(AlignMode.Right, '0')]
        public string HEDEFBANKA { get; set; }

        [FieldFixedLength(5)]
        [FieldAlign(AlignMode.Right, '0')]
        public string HEDEFSUBE { get; set; }

        [FieldFixedLength(19)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string HEDEFHESAPNUMARASI { get; set; }

        [FieldFixedLength(3)]
        public string PARAKODU { get; set; }
        [FieldFixedLength(20)]

        [FieldAlign(AlignMode.Right, '0')]
        public decimal TUTAR { get; set; }

        [FieldFixedLength(60)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string ACIKLAMA { get; set; }

        [FieldFixedLength(20)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string FIRMAREFERANS { get; set; }

        [FieldFixedLength(50)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string UNVAN { get; set; }

        [FieldFixedLength(50)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string ADDRESS { get; set; }

        [FieldFixedLength(10)]

        [FieldAlign(AlignMode.Right, ' ')]
        public string TELEFON { get; set; }

        [FieldFixedLength(10)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string VERGIKIMLIKNO { get; set; }

        [FieldFixedLength(30)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string VERGIDAIRESI { get; set; }

        [FieldFixedLength(150)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string EMAIL { get; set; }

        [FieldFixedLength(26)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string IBAN { get; set; }

        [FieldFixedLength(16)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string TCKN { get; set; }
    }

    [FixedLengthRecord(FixedMode.ExactLength)]
    [IgnoreEmptyLines]
    [IgnoreFirst(1)]
    [IgnoreLast(1)]
    public class PAYMENTOUTCOME
    {
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TYPE;

        [FieldFixedLength(4)]
        [FieldAlign(AlignMode.Right, '0')]
        public int BANKCODE;

        [FieldFixedLength(5)]
        [FieldAlign(AlignMode.Right, '0')]
        public int BRANCHCODE;

        [FieldFixedLength(19)]
        [FieldAlign(AlignMode.Right, ' ')]
        public string ACCOUNTNO;

        [FieldFixedLength(3)]
        public string CURRENCYCODE;

        [FieldFixedLength(20)]
        [FieldAlign(AlignMode.Right, '0')]
        public string AMOUNT;

        [FieldFixedLength(60)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string DESCRIPTION;

        [FieldFixedLength(20)]
        [FieldAlign(AlignMode.Left, ' ')]
        public string COMPANYREF;

        [FieldFixedLength(1)]
        public int PAYMENTSTATUS;

        [FieldFixedLength(6)]
        [FieldAlign(AlignMode.Right, ' ')]
        public int TRANSACTIONNO;

        [FieldFixedLength(8)]
        //[FieldConverter(ConverterKind.Date,"ddMMyyyy")]
        public int TRANSACTION_DATE;

        [FieldFixedLength(8)]
        [FieldAlign(AlignMode.Left, '0')]
        public int EFTQUERYNO;

        [FieldFixedLength(26)]
        public string IBAN;
    }

    [FixedLengthRecord(FixedMode.ExactLength)]
    public class FOOTER
    {
        [FieldFixedLength(1)]
        public string PAYMENT_TYPE { get; set; }

        [FieldFixedLength(12)]
        [FieldAlign(AlignMode.Right, '0')]
        public string PAYMENT_COUNT { get; set; }

        [FieldFixedLength(20)]
        [FieldAlign(AlignMode.Right, '0')]
        public string PAYMENT_TOTAL { get; set; }
    }
}
