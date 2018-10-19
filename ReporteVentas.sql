SELECT distinct RTRIM(vm.FolioDocumento) as Folio, RTRIM(cl.ManejarPrecioEspecial) as [Pecio Especial], RTRIM(cl.RazonSocial) as Cliente, RTRIM(cl.CodigoCliente) as [Codigo Cliente], RTRIM(cl.RFC) as RFC, RTRIM(arc.descripcion) as [Clasificación Articulo], RTRIM(tp.DescripcionTipoDePrecio) as [Tipo de Precio], RTRIM(mn.Descripcion) as Moneda, RTRIM(vm.TipoDeCambio) as TC_Ventas, RTRIM(vm.TipoDeCambio_DOF) as TC_DOF, RTRIM(vm.naturalezaPago) as [Naturaleza Pago], RTRIM(fp.Descripcion) as [Forma Pago], RTRIM(vd.CantidadVendida) as Cantidad, RTRIM(ar.c_ClaveProdServ) as [Clave Producto], RTRIM(ar.CodigoArticulo) as [Codigo Articulo], RTRIM(ar.DescripcionArticulo) as Descripcion, RTRIM(are.encriptado) as Encriptado, RTRIM(um.DescripcionUnidadMedida) as [Unidad Medida], RTRIM(fp.Descripcion) as [Forma Pago], RTRIM(vd.PrecioVentaUnitario) as [Precio(Articulo)], RTRIM(vd.ImporteVenta) as [Importe(Articulo)], RTRIM(em.NombreCorto) as Vendedor, RTRIM(vm.SubTotal) AS Subtotal, RTRIM(vm.IVA) as IVA, RTRIM(vm.Total) as Total
  from tbVentasMaestro vm 
inner join tbVentasDetalle vd on vm.idVentasMaestro = vd.idVentasMaestro 
inner join tbArticulos ar on vd.idArticulo = ar.idArticulo 
inner join tbArticulosClasificacion arc on ar.idArticulosClasificacion = arc.idArticulosClasificacion 
inner join tbUnidadesDeMedida um on ar.idUnidadMedida = um.idUnidadMedida 
inner join tbTiposDocumentoFolio td ON vm.idTipoDocumentoFolio = td.idTipoDocumentoFolio 
inner join tbClientes cl on vm.idCliente = CL.idCliente 
inner join tbTiposDePrecios tp on vd.idTipoDePrecio = tp.idTipoDePrecio and tp.status <> 'CA' 
inner join tbMonedas mn on vm.idMoneda = mn.idMoneda 
inner join tbEmpleados em on vm.idEmpleado = em.idEmpleado 
inner join tbFormasDePago fp on vm.idFormaDePago = fp.idFormaDePago 
inner join tbarticulosencriptados are on ar.CodigoArticulo = are.codigoarticulo 
inner join tbSucursales sc on vm.idSucursal = sc.idSucursal 
where vm.FechaVentaANSI > (select convert(varchar(8),convert(datetime,'2018-09-01',101),112)) and vm.FechaVentaANSI < (select convert(varchar(8),convert(datetime,'2018-09-12',101),112))  
 and td.idTipoDocumentoFolio = 31 or td.idTipoDocumentoFolio = 32 or td.idTipoDocumentoFolio = 33 or td.idTipoDocumentoFolio = 34  
 and vm.idSucursal = 1 


 SELECT convert(varchar(10), cast(FechaVentaANSI AS varchar(8)),103) from tbVentasMaestro vm






