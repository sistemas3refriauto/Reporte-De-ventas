using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Web;
using ADGV;
using System.Globalization;

namespace ReporteDeVentas
{
    public partial class FrmReporteVentas : Form
    {
        private clsFunciones funciones = new clsFunciones();
        private int ini;
        private string HostConexion = "";
        private int idSucursal;
        private string select;
        private BindingSource bs = new BindingSource();
        private string filename;
        private string sCnn;
        private DataTable dt = new DataTable();
        private string sSel;

        public FrmReporteVentas()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = true;
        }
        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {
            DateTime actual = DateTime.Today;
            string mes;
            string año;
            mes = actual.Month.ToString();
            año = actual.Year.ToString();
            dtpDesde.Value = Convert.ToDateTime("01-" + mes + "-" + año + "");
            hasta.Value = Convert.ToDateTime(actual);
            hasta.MaxDate = DateTime.Today;
            ini = funciones.ExtraeConexionDelINI();
            ExtraerHost(ini);
            LoadCmb();
            AddColDGV();
        }
        private void LoadCmb()
        {
            string user = "user_selects";
            string pass = "us3r$" + idSucursal;
            sCnn = "data source = " + HostConexion + "; initial catalog = dbSIA; user id = " + user + "; password = " + pass + "";
            try
            {
                string sSel = "select RTRIM(td.Descripcion) as Descripcion,RTRIM(td.idTipoDocumentoFolio) as idTipoDocumentoFolio ";
                sSel += "from tbTiposDocumentoFolio td ";
                sSel += "where td.idTipoDocumentoFolio = 31 or td.idTipoDocumentoFolio = 32 or td.idTipoDocumentoFolio = 33 or td.idTipoDocumentoFolio = 34";
                SqlConnection cnSQL = new SqlConnection(sCnn);
                SqlCommand cmd = new SqlCommand(sSel, cnSQL);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Rows.Add("FACTURAS Y RECIBOS", 0);
                cbTipoMovimiento.DisplayMember = "Descripcion";
                cbTipoMovimiento.ValueMember = "idTipoDocumentoFolio";
                cbTipoMovimiento.DataSource = dt;

                cbTipoMovimiento.SelectedValue = 31;

                cnSQL.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            helperTotal();
            obtenerCampos();
            if (select != "")
            {
                dataGridView.Visible = true;
                ObtieneDatos();
            }
            else
            {
                //SI EL REPORTE NO TIENE CAMPOS SELECCIONADOS SE VISUALIZA UNO GENERAL Y SE PALOMEAN LOS CHECKBOX CORRESPONDIENTES
                select = "RTRIM(cl.CodigoCliente) as [Codigo Cliente], RTRIM(cl.RazonSocial) as Cliente,RTRIM(cl.RFC) as RFC,RTRIM(arc.descripcion) as ClasificaciónArticulo,RTRIM(tp.DescripcionTipoDePrecio) as [Tipo de Precio],RTRIM(mn.Descripcion) as Moneda,RTRIM(ar.c_ClaveProdServ) as [Clave del Producto],RTRIM(ar.CodigoArticulo) as [Codigo del Articulo],";
                select += "RTRIM(vd.ImporteVenta) as [Importe(Articulo)],RTRIM(em.NombreCorto) as Vendedor";
                dataGridCampo.Rows[3].Cells[1].Value = true;
                dataGridCampo.Rows[2].Cells[1].Value = true;
                dataGridCampo.Rows[4].Cells[1].Value = true;
                dataGridCampo.Rows[5].Cells[1].Value = true;
                dataGridCampo.Rows[6].Cells[1].Value = true;
                dataGridCampo.Rows[7].Cells[1].Value = true;
                dataGridCampo.Rows[14].Cells[1].Value = true;
                dataGridCampo.Rows[15].Cells[1].Value = true;
                dataGridCampo.Rows[20].Cells[1].Value = true;
                dataGridCampo.Rows[21].Cells[1].Value = true;
                ObtieneDatos();
            }
        }

        private void helperTotal()
        {
            int cont = 0;
            bool Help = false;
            foreach (DataGridViewRow row in dataGridCampo.Rows)
            {

                if (cont == 5 || cont == 13 || cont == 14 || cont == 16 || cont == 16 || cont == 17 || cont == 18 || cont == 19 || cont == 20)
                {

                    bool isSelected = Convert.ToBoolean(row.Cells["selecciona"].Value);
                    if (isSelected)
                    {
                        Help = true;
                    }
                }
                if (Help)
                {
                    if (cont == 22 || cont == 23 || cont == 24)
                    {
                        row.Cells["selecciona"].Value = false;
                    }
                }
                cont++;
            }
        }

        private void AddDataDT()
        {
            dt = new DataTable();
            dt.Columns.Add("Folio", typeof(int));
            dt.Columns.Add("Precio Especial", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Codigo Cliente", typeof(int));
            dt.Columns.Add("RFC", typeof(string));
            dt.Columns.Add("Clasificación Articulo", typeof(string));
            dt.Columns.Add("Tipo de Precio", typeof(string));
            dt.Columns.Add("Moneda", typeof(string));
            dt.Columns.Add("TC_Ventas", typeof(float));
            dt.Columns.Add("TC_DOF", typeof(float));
            dt.Columns.Add("Fecha Venta", typeof(DateTime));
            dt.Columns.Add("Naturaleza Pago", typeof(string));
            dt.Columns.Add("Forma Pago", typeof(string));
            dt.Columns.Add("Cantidad", typeof(float));
            dt.Columns.Add("Clave Producto", typeof(string));
            dt.Columns.Add("Codigo Articulo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Encriptado", typeof(string));
            dt.Columns.Add("Unidad Medida", typeof(string));
            dt.Columns.Add("Precio(Articulo)", typeof(float));
            dt.Columns.Add("Importe(Articulo)", typeof(float));
            dt.Columns.Add("Vendedor", typeof(string));
            dt.Columns.Add("Subtotal", typeof(float));
            dt.Columns.Add("IVA", typeof(float));
            dt.Columns.Add("Total", typeof(float));
        }
        private void obtenerCampos()
        {
            string aux = string.Empty;
            foreach (DataGridViewRow row in dataGridCampo.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selecciona"].Value);
                if (isSelected)
                {
                    aux += Convert.ToString(row.Cells["CampoBD"].Value) + ", ";
                }
            }
            select = aux.TrimEnd(',', ' ');
        }
        private void ObtieneDatos()
        {
            dt = new DataTable();
            //bs.DataSource = dt.DefaultView;
            bs = new BindingSource();
            dataGridView.DataSource = bs;
            dataGridView.Columns.Clear();
            AddDataDT();
            dataGridView.Columns.Clear();

            string tipoMovimiento;
            if (Convert.ToInt32(cbTipoMovimiento.SelectedValue) == 0)
            {
                tipoMovimiento = " and (td.idTipoDocumentoFolio = 31 or td.idTipoDocumentoFolio = 32)";
            }
            else
            {
                tipoMovimiento = " and td.idTipoDocumentoFolio =" + cbTipoMovimiento.SelectedValue.ToString();
            }
            string user = "user_selects";
            string pass = "us3r$" + idSucursal;
            string fechaDesde = dtpDesde.Value.ToString("dd-MM-yyyy");
            string fechaHasta = hasta.Value.ToString("dd-MM-yyyy");
            sCnn = "data source = " + HostConexion + "; initial catalog = dbSIA; user id = " + user + "; password = " + pass + "";
            sSel = "SELECT distinct " + select;
            sSel += "\n ";
            sSel += " from tbVentasMaestro vm \n";
            sSel += "inner join tbVentasDetalle vd on vm.idVentasMaestro = vd.idVentasMaestro \n";
            sSel += "inner join tbArticulos ar on vd.idArticulo = ar.idArticulo \n";
            sSel += "inner join tbArticulosClasificacion arc on ar.idArticulosClasificacion = arc.idArticulosClasificacion \n";
            sSel += "inner join tbUnidadesDeMedida um on ar.idUnidadMedida = um.idUnidadMedida \n";
            sSel += "inner join tbTiposDocumentoFolio td ON vm.idTipoDocumentoFolio = td.idTipoDocumentoFolio \n";
            sSel += "inner join tbClientes cl on vm.idCliente = CL.idCliente \n";
            sSel += "inner join tbTiposDePrecios tp on vd.idTipoDePrecio = tp.idTipoDePrecio \n";
            sSel += "inner join tbMonedas mn on vm.idMoneda = mn.idMoneda \n";
            sSel += "inner join tbEmpleados em on vm.idEmpleado = em.idEmpleado \n";
            sSel += "inner join tbFormasDePago fp on vm.idFormaDePago = fp.idFormaDePago \n";
            sSel += "inner join tbarticulosencriptados are on ar.CodigoArticulo = are.codigoarticulo \n";
            sSel += "inner join tbSucursales sc on vm.idSucursal = sc.idSucursal \n";
            sSel += "where (convert(varchar, CONVERT(datetime,STR(vm.FechaVentaANSI)),105))  between (select convert(datetime,'" + fechaDesde + "',103)) and  (select convert(datetime,'" + fechaHasta + "',103))  \n";
            sSel += "" + tipoMovimiento + "  \n";
            sSel += " and vm.idSucursal = " + idSucursal.ToString() + " \n";
            sSel += "and tp.status <> 'CA'";
            SqlConnection cnSQL = new SqlConnection(sCnn);
            try
            {
                cnSQL.Open();
                SqlCommand cmd = new SqlCommand(sSel, cnSQL);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //eliminamos columnas en blanco
                ClearDT(dt);
                bs.DataMember = dt.TableName;
                bs.DataSource = dt.DefaultView;
                dataGridView.DataSource = bs;
                cnSQL.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ClearDT(DataTable dt)
        {
            #region trash
            /*
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    if (dt.Rows[i][j].ToString() == "")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        dt.Columns.Remove(dt.Columns[j]);                     
                    }                   
                }
            }*/
            #endregion
            int cont = 0;
            foreach (DataGridViewRow row in dataGridCampo.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selecciona"].Value);
                if (!isSelected)
                {
                    dt.Columns.Remove(dt.Columns[cont]);
                    cont = cont - 1;
                }
                cont = cont + 1;
            }
            #region eliminar columnas en blanco
            List<int> colums = new List<int>();
            if (dt.Rows.Count > 0)
            {
                int colum = dataGridCampo.ColumnCount;
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    bool delColum = true;
                    foreach (DataRow row in dt.Rows)
                    {

                        string value = row[j].ToString();
                        if (value != "")
                            delColum = false;
                    }
                    if (delColum)
                        colums.Add(j);
                }
                int cound = 0;
                foreach(int s in colums)
                {
                    dt.Columns.Remove(dt.Columns[s-cound]);
                    cound++;
                   // dgccc.Add(dataGridCampo.Columns[s]);
                }
                
            }
            #endregion
        }
        private void dataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dataGridView.FilterString;
        }
        private void dataGridView_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = this.dataGridView.SortString;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount == 0)
            {
                MessageBox.Show("No Hay Datos Para Realizar Un Reporte");
            }
            else
            {
                //ESCOJE A RUTA DONDE GUARDAREMOS EL PDF 
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    filename = save.FileName;
                    //definimos la hoja y los margenes
                    Document doc = new Document(PageSize.LETTER.Rotate(), 10f, 10f, 10f, 10f);
                    try
                    {
                        //LA FUENTE DE NUESTRO TEXTO
                        iTextSharp.text.Font fuente = FontFactory.GetFont("Times New Roman", 10, new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#000")));
                        DateTime thisDay = DateTime.Today;
                        Paragraph para = new Paragraph(thisDay.ToString("D"), fuente);
                        FileStream file = new FileStream(filename, FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(doc, file);
                        writer.ViewerPreferences = PdfWriter.PageModeUseThumbs;
                        writer.ViewerPreferences = PdfWriter.PageLayoutOneColumn;

                        doc.Open();

                        // Creamos la imagen y le ajustamos el tamaño
                        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(Application.StartupPath + "/refriauto.png");
                        imagen.BorderWidth = 0;
                        imagen.Alignment = Element.ALIGN_LEFT;
                        float percentage = 0.0f;
                        percentage = 150 / imagen.Width;
                        imagen.ScalePercent(percentage * 90);
                        // Insertamos la imagen en el documento
                        doc.Add(imagen);
                        // Insertamos la fecha
                        para.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(para);
                        doc.Add(new Paragraph(" "));

                        //metodo para generar el reporte
                        GenerarDocumentos(doc);

                        Process.Start(filename);
                        doc.Close();
                        writer.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public void GenerarDocumentos(Document document)
        {
            //se crea un objeto PdfTable con el numero de columnas del dataGridView 
            PdfPTable datatable = new PdfPTable(dataGridView.ColumnCount);
            //se crea el encabezado del reporte
            PdfPTable encabezado = new PdfPTable(1);
            //obtenemos el tamaño de las columnas
            float[] headerwidths = GetTamañoColumnas(dataGridView);
            //asignamos algunas propiedades para el diseño del pdf           
            datatable.DefaultCell.Padding = 1;
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            encabezado.WidthPercentage = 100;

            //fuente del texto
            iTextSharp.text.Font fuente = FontFactory.GetFont("Calibri (Body)", 9, new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#fff")));

            Phrase objP = new Phrase("A", fuente);

            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_BOTTOM;
            encabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            //insertamos el encabezado al documento
            objP = new Phrase("Reporte de Ventas", fuente);
            encabezado.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(108, 108, 108);
            encabezado.DefaultCell.UseVariableBorders = true;
            encabezado.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(108, 108, 108);
            encabezado.DefaultCell.UseVariableBorders = true;
            encabezado.DefaultCell.BorderColorTop = new iTextSharp.text.BaseColor(255, 255, 255);
            encabezado.AddCell(objP);
            //fuente del texto
            fuente = FontFactory.GetFont("Calibri (Body)", 8, new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#fff")));

            //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF         
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                objP = new Phrase(dataGridView.Columns[i].HeaderText, fuente);
                datatable.DefaultCell.UseVariableBorders = true;
                datatable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(108, 108, 108);
                datatable.DefaultCell.UseVariableBorders = true;
                datatable.DefaultCell.BorderColor = new iTextSharp.text.BaseColor(108, 108, 108);
                datatable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.AddCell(objP);
            }
            //fuente del texto
            fuente = FontFactory.GetFont("Calibri (Body)", 8, new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#000")));
            //SE GENERA EL CUERPO DEL PDF 
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    //formato a la fecha dd/mm/yyyy
                    if (dataGridView.Columns[j].Name == "Fecha Venta")
                    {
                        dataGridView.Columns[j].ValueType = Type.GetType("System.String");
                        string fecha = dataGridView[j, i].Value.ToString().Substring(0, 10);
                        objP = new Phrase(fecha, fuente);
                    }
                    else
                    {
                        objP = new Phrase(dataGridView[j, i].Value.ToString(), fuente);
                    }
                    datatable.DefaultCell.UseVariableBorders = true;
                    datatable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
                    datatable.DefaultCell.UseVariableBorders = true;
                    datatable.DefaultCell.BorderColorLeft = new iTextSharp.text.BaseColor(255, 255, 255);
                    datatable.DefaultCell.UseVariableBorders = true;
                    datatable.DefaultCell.BorderColorRight = new iTextSharp.text.BaseColor(255, 255, 255);
                    datatable.DefaultCell.UseVariableBorders = true;
                    datatable.DefaultCell.BorderColorTop = new iTextSharp.text.BaseColor(108, 108, 108);
                    datatable.HorizontalAlignment = Element.ALIGN_CENTER;
                    datatable.AddCell(objP);
                }
            }
            //insertamos encabezado y el cuerpo del pdf
            document.Add(encabezado);
            document.Add(datatable);
        }
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            //Tomamos el numero de columnas 
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                //Tomamos el ancho de cada columna 
                values[i] = (int)dg.Columns[i].Width;
            }
            return values;
        }
        private void AddColDGV()
        {
            //Se agregan los campos del reporte
            dataGridCampo.Rows.Add("Folio", false, "RTRIM(vm.FolioDocumento) as Folio", typeof(int));
            dataGridCampo.Rows.Add("Precio Especial", false, "RTRIM(cl.ManejarPrecioEspecial) as [Pecio Especial]", typeof(string));
            dataGridCampo.Rows.Add("Cliente", false, "RTRIM(cl.RazonSocial) as Cliente", typeof(string));
            dataGridCampo.Rows.Add("Codigo Cliente", false, "RTRIM(cl.CodigoCliente) as [Codigo Cliente]", typeof(int));
            dataGridCampo.Rows.Add("RFC", false, "RTRIM(cl.RFC) as RFC", typeof(string));
            dataGridCampo.Rows.Add("Clasificacion Articulo", false, "RTRIM(arc.descripcion) as [Clasificación Articulo]", typeof(string));
            dataGridCampo.Rows.Add("Tipo de Precio", false, "RTRIM(tp.DescripcionTipoDePrecio) as [Tipo de Precio]", typeof(string));
            dataGridCampo.Rows.Add("Moneda", false, "RTRIM(mn.Descripcion) as Moneda", typeof(string));
            dataGridCampo.Rows.Add("TC_Ventas", false, "RTRIM(vm.TipoDeCambio) as TC_Ventas", typeof(float));
            dataGridCampo.Rows.Add("TC_DOF", false, "RTRIM(vm.TipoDeCambio_DOF) as TC_DOF", typeof(float));
            dataGridCampo.Rows.Add("Fecha Venta", false, "convert(varchar, CONVERT(datetime,STR(vm.FechaVentaANSI)),103) as [Fecha Venta]", typeof(DateTime));
            dataGridCampo.Rows.Add("Naturaleza de Pago", false, "RTRIM(vm.naturalezaPago) as [Naturaleza Pago]", typeof(string));
            dataGridCampo.Rows.Add("Forma de Pago", false, "RTRIM(fp.Descripcion) as [Forma Pago]", typeof(string));
            dataGridCampo.Rows.Add("Cantidad Vendida", false, "RTRIM(vd.CantidadVendida) as Cantidad", typeof(float));
            dataGridCampo.Rows.Add("Clave del Producto", false, "RTRIM(ar.c_ClaveProdServ) as [Clave Producto]", typeof(string));
            dataGridCampo.Rows.Add("Codigo del Articulo", false, "RTRIM(ar.CodigoArticulo) as [Codigo Articulo]", typeof(string));
            dataGridCampo.Rows.Add("Descripcion Articulo", false, "RTRIM(vd.DescripcionArticulo) as Descripcion", typeof(string));
            dataGridCampo.Rows.Add("Encriptado del Articulo", false, "RTRIM(are.encriptado) as Encriptado", typeof(string));
            dataGridCampo.Rows.Add("Unidad Medida", false, "RTRIM(um.DescripcionUnidadMedida) as [Unidad Medida]", typeof(string));
            dataGridCampo.Rows.Add("Precio(Articulo)", false, "RTRIM(vd.PrecioVentaUnitario) as [Precio(Articulo)]", typeof(float));
            dataGridCampo.Rows.Add("Importe(Articulo)", false, "RTRIM(vd.ImporteVenta) as [Importe(Articulo)]", typeof(float));
            dataGridCampo.Rows.Add("Vendedor", false, "RTRIM(em.NombreCorto) as Vendedor", typeof(string));
            dataGridCampo.Rows.Add("SubTotal", false, "RTRIM(vm.SubTotal) AS Subtotal", typeof(float));
            dataGridCampo.Rows.Add("Iva", false, "RTRIM(vm.IVA) as IVA", typeof(float));
            dataGridCampo.Rows.Add("Total", false, "RTRIM(vm.Total) as Total", typeof(float));
        }
        public string ExtraerHost(int ini)
        {
            switch (ini)
            {
                case 1:
                    HostConexion = "serversia";
                    idSucursal = 1;
                    break;
                case 2:
                    HostConexion = "refriautoobregon.ddns.net";
                    idSucursal = 10;
                    break;

                case 3:
                    HostConexion = "refriautomatriz.ddns.net";
                    idSucursal = 1;
                    break;
                case 4:
                    HostConexion = "ALBERTO-PC";
                    idSucursal = 6;
                    break;
                case 5:
                    HostConexion = "refriautomatriz.ddns.net";
                    idSucursal = 1;
                    break;
                case 6:
                    HostConexion = "SERVERVILLAH";
                    idSucursal = 7;
                    break;
                case 7:
                    HostConexion = "Refricaborca";
                    idSucursal = 8;
                    break;
                case 8:
                    HostConexion = "serversia";
                    idSucursal = 9;
                    break;
                case 9:
                    HostConexion = "refriautorefa.ddns.net";
                    idSucursal = 9;
                    break;
                case 10:
                    HostConexion = "Mario";
                    idSucursal = 1;
                    break;
                case 11:
                    HostConexion = "refriautoMario.ddns.net";
                    idSucursal = 1;
                    break;
                case 12:
                    HostConexion = "refriautocaborca.ddns.net";
                    idSucursal = 8;
                    break;
                case 13:
                    HostConexion = "SERVERSIAMOCHIS";
                    idSucursal = 5;
                    break;
                case 14:
                    HostConexion = "refriautovillah.ddns.net";
                    idSucursal = 7;
                    break;
                case 15:
                    HostConexion = "serverchihuahua";
                    idSucursal = 11;
                    break;
                case 16:
                    HostConexion = "refriautochihuahua.ddns.net";
                    idSucursal = 11;
                    break;
                case 17:
                    HostConexion = "refriautomochis.ddns.net";
                    idSucursal = 5;
                    break;
                case 18:
                    HostConexion = "refriautolapaz.ddns.net";
                    idSucursal = 6;
                    break;
                case 19:
                    HostConexion = "server(dbSIACLAUDIA)";
                    idSucursal = 1;
                    break;
                case 20:
                    HostConexion = "ingenierora";
                    idSucursal = 1;
                    break;
                case 21:
                    HostConexion = "SERVEROBREGON";
                    idSucursal = 10;
                    break;
                case 22:
                    HostConexion = "SERVERCOLIMA";
                    idSucursal = 12;
                    break;
                case 23:
                    HostConexion = "MEXICALI2-PC";
                    idSucursal = 13;
                    break;
                case 24:
                    HostConexion = "SERVERCOATZA";
                    idSucursal = 14;
                    break;
                case 25:
                    HostConexion = "refriautocoatza.ddns.net";
                    idSucursal = 14;
                    break;
                case 26:
                    HostConexion = "refriautomexicali.ddns.net";
                    idSucursal = 13;
                    break;
                case 27:
                    HostConexion = "refriautocolima.ddns.net";
                    idSucursal = 12;
                    break;
                case 28:
                    HostConexion = "servlan(dbM)";
                    idSucursal = 1;
                    break;
                case 29:
                    HostConexion = "refriautoveracruz.ddns.net";
                    idSucursal = 15;
                    break;
                case 30:
                    HostConexion = "SERVERVERACRUZ";
                    idSucursal = 15;
                    break;
                case 31:
                    HostConexion = "serversia";
                    idSucursal = 16;
                    break;
                case 32:
                    HostConexion = "refriautocoatza2.ddns.net";
                    idSucursal = 16;
                    break;
                case 33:
                    HostConexion = "serversia(cancun)";
                    idSucursal = 17;
                    break;
                case 34:
                    HostConexion = "refriautocancun.ddns.net";
                    idSucursal = 17;
                    break;
                case 35:
                    HostConexion = "serversia";
                    idSucursal = 18;
                    break;
                case 36:
                    HostConexion = "refriautounison.ddns.net";
                    idSucursal = 18;
                    break;
                case 37:
                    HostConexion = "serversia";
                    idSucursal = 19;
                    break;
                case 38:
                    HostConexion = "refriautogaspar.ddns.net";
                    idSucursal = 19;
                    break;
                case 39:
                    HostConexion = "serversia";
                    idSucursal = 20;
                    break;
                case 40:
                    HostConexion = "refriautonavojoa.ddns.net";
                    idSucursal = 20;
                    break;
                case 41:
                    HostConexion = "serversia";
                    idSucursal = 21;
                    break;
                case 42:
                    HostConexion = "refriautotuxtla.ddns.net";
                    idSucursal = 21;
                    break;
                case 43:
                    HostConexion = "serversia";
                    idSucursal = 23;
                    break;
                case 44:
                    HostConexion = "refriautogdl.ddns.net";
                    idSucursal = 23;
                    break;
                case 47:
                    HostConexion = "SERVERMODELO";
                    idSucursal = 24;
                    break;
                case 48:
                    HostConexion = "refriautomodelo.ddns.net";
                    idSucursal = 24;
                    break;
                case 49:
                    HostConexion = "SERVERTALLER";
                    idSucursal = 25;
                    break;
                case 50:
                    HostConexion = "refriautotaller.ddns.net";
                    idSucursal = 25;
                    break;
                case 51:
                    HostConexion = "SERVERCOMAL";
                    idSucursal = 26;
                    break;
                case 52:
                    HostConexion = "refriautocomal.ddns.net";
                    idSucursal = 26;
                    break;
            }
            return HostConexion;
        }

        
    }
}
