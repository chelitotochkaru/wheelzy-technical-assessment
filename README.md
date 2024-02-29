# Wheelzy

1) Para la resolución de este punto se desarrolló un API RESTful utilizando NET 6 y EF.<br />
   Se utlizó el modelo Domain-Driven Design (DDD) para su arquitectura.<br />
   Para la creación de la base de datos se resolvió utilizando EF Migrations y también se utilizó EF Data Seeding para la populación de la misma.<br />
   El script solicitado se encuentra en [/databases/scripts/get_orders.sql](https://github.com/chelitotochkaru/wheelzy-technical-assessment/blob/dev/databases/scripts/get_orders.sql)<br />
   El equivalente del script en EF se consume desde el endpoint [GET] /orders.
2) Para resolver este tipo de situaciones se me ocurre implementar alguna herramienta de cache (2nd-Level Cache / In-Memory Cache) como Redis, Memcached, Cassandra, etc.
3) * En mi experiencia el método SingleOrDefault() es menos performante que FirstOrDefault().
   * Validar que el FirstOrDefault no sea null antes de actualizar la propiedad.
   * Quitar el método dbContext.SaveChanges() de la iteración para evitar las multiples llamadas a la base de datos.<br /><br/>
   ```csharp
   public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
   {
      foreach (var invoice in invoices)
      {
         var customer = dbContext.Customers.FirstOrDefault(invoicei.CustomerId.Value);
         if (customer != null)
         {
            customer.Balance -= invoice.Total;
         }
      }
      dbContext.SaveChanges();
   }
   ```
4) La resolución de este punto se consume desde el endpoint [GET] /orders/search.<br />

   > **Comentarios**<br /><br />
   > El método expuesto en el enunciado es Task\<OrderDTO\> GetOrders(), lo cambié a Task\<IEnumerable\<OrderDTO\>\> GetOrders() ya que el nombre esta pluralizado, y en efecto la consulta devuelve 0 o N registros.<br /><br />
   > También se indica que si algún "filtro" no viene no debe tenerse en cuenta en la búsqueda. El único parámetro _nullable_ es isActive, por lo que hace que el resto de los parámetros sean obligatorios. 🧐<br /><br />
   > El parámetro isActive da a entender que la base de datos debería utilizar borrado lógico(**SoftDelete**); no lo implementé pero tengo conocimiento de como hacerlo en EF, interfiriendo todas las consultas para que no se tenga que ir especificando el [Entity].Active=true.<br /><br />

5) Asumiendo que se utliza el modelo de git-flow para el manejo de branches:
   * Actualizar el estado del issue reportado en 'In Progress'
   * Actualizar el branch 'dev'.
   * Intentar reproducir el error reportado.
   * Crear el nuevo branch bug/[issue] desde 'dev'.
   * Corregir el error.
   * Hacer una mínima prueba manual (si el proyecto trabaja con UnitTest, crear el UnitTest del mismo).
   * Commitear el cambio.
   * Pushear el branch al repositorio remoto.
   * Crear el Pull Request/Merge Request.
   * Actualizar el estado del issue reportado en 'Done' (en algunos tableros se utiliza un estado QA, y recién cuando el departamente de QA valida que el bug esta corregido se pasa a 'Done').

## Ejecución del proyecto

Clonar el proyecto:<br />

```
git clone https://github.com/chelitotochkaru/wheelzy-technical-assessment.git
```

Una vez abierta la solución se debe configurar la conexión de la base de datos en el archivo ***src/Wheelzy.API/appsettings.Development.json:***
```json
"ConnectionStrings": {
   "Default": "Server=[server];Database=wheelzy;User=[user];Password=[password];Trusted_Connection=False;TrustServerCertificate=True;"
}
```
> En el caso que no se configure usuario _sa_, el usuario configurado debe tener permisos de creación debido a que EF Migrations va a intentar crear la base de datos en el caso que no exista.<br />
> La creación y ejecución de las migraciones se ejecutan de forma automática en cada ejecución del proyecto (solo en ambientes _no productivos_).

Ejecutar el proyecto y... voilá!

## Nota final

Disfruté mucho hacer este challenge. Si bien entiendo que podría haber enviado código suelto o un diagrama de la base de datos, o un .sql con la definición de la misma, preferí invertir unas horas más y entregar un proyecto 100% funcional, con la implementación del punto (4 lista para ser ejecutada y probada.

¡Saludos!
