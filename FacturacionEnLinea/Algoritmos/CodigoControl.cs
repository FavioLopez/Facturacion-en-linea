using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos
{
    public class CodigoControl
    {
        private Verhoeff ver;
        private AllegedRC4 allegedRC4;
        private Base64 base64;
        public string GenerarCodigoControl(string NumAutorizacion, string NumFactura, string NitCi, string FechaTran, string MontoTran, string LlaveDosi)
        {
            LlaveDosi = @"" + LlaveDosi;//reconocer la barra invertida como ascii
            double MontoTranInt = Math.Round(Convert.ToDouble(MontoTran), MidpointRounding.AwayFromZero);
            //Math.Ceiling
            MontoTran = MontoTranInt.ToString();
            //PASO 1 FiveDigitVarVerhoeff

            NumFactura = AddDigitVerhoeff(NumFactura, 2);
            NitCi = AddDigitVerhoeff(NitCi, 2);
            FechaTran = AddDigitVerhoeff(FechaTran, 2);
            MontoTran = AddDigitVerhoeff(MontoTran, 2);


            Int64 suma = Convert.ToInt64(NumFactura) + Convert.ToInt64(NitCi) + Convert.ToInt64(FechaTran) + Convert.ToInt64(MontoTran);

            string FiveDigitVarVerhoeff = AddDigitVerhoeff(suma.ToString(), 5).Substring(suma.ToString().Length, 5);//sacar 5 digitos de verhoeff


            //PASO 2
            int[] vector = new int[FiveDigitVarVerhoeff.Length];//largo de las cadenas 
            string CadenaConcatenada = "";
            string[] valoresCadena = { NumAutorizacion, NumFactura, NitCi, FechaTran, MontoTran };//aumentado las cadenas a cada valor
            int inicial = 0;
            for (int i = 0; i < FiveDigitVarVerhoeff.Length; i++)
            {
                vector[i] = Convert.ToInt16(FiveDigitVarVerhoeff[i].ToString()) + 1;
                valoresCadena[i] += LlaveDosi.Substring(inicial, vector[i]);
                inicial += vector[i];
                CadenaConcatenada += valoresCadena[i];
            }
            //PASO 3 ALLEGED
            allegedRC4 = new AllegedRC4();

            string llaveCifrada = LlaveDosi + FiveDigitVarVerhoeff;
            string AllegedRC4cadena = allegedRC4.CifrarMensajeRC4(CadenaConcatenada, llaveCifrada, true);

            //PASO 4 int ST= sumatotal SP=sumaparcialint ST = 0; 
            int ST = 0;
            int SF = 0;
            int[] SP = { 0, 0, 0, 0, 0 };

            for (int i = 0; i < AllegedRC4cadena.Length; i++)
            {
                ST += AllegedRC4cadena[i];
                SP[i % 5] += AllegedRC4cadena[i];
            }
            //PASO 5 SF=suma finalint SF = 0;
            for (int i = 0; i < SP.Length; i++)
            {
                SF += (ST * SP[i]) / vector[i];
            }
            base64 = new Base64();
            string CadenaBase64 = base64.ObtenerBase64(SF);

            //PASO 6
            string codigoControl = allegedRC4.CifrarMensajeRC4(CadenaBase64, LlaveDosi + FiveDigitVarVerhoeff, false);
            return codigoControl;

        }
        private string AddDigitVerhoeff(string valor, int num)
        {
            ver = new Verhoeff();
            for (int i = 0; i < num; i++)
            {
                valor += ver.ObtenerVerhoeff(valor).ToString();
            }
            return valor;
        }
    }
}
