using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteDeVentas
{
    public class clsFunciones
    {
        public int ExtraeConexionDelINI()
        {
            StreamReader objReader = new StreamReader("c:\\Sia.ini");
            string sLine = "";
            int idSucursalLogeada = 0;
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText)
            {
                idSucursalLogeada = Convert.ToInt32(sOutput);
            }
            return idSucursalLogeada;
        }
    }
}
