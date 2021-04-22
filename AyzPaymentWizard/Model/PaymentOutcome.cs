using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzPaymentWizard.Model
{
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
}
