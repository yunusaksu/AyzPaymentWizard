using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AyzPaymentWizard.FileTransfer;

namespace AyzPaymentWizard
{
    public static class FileTransfer
    {
        [FixedLengthRecord()]
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
}
