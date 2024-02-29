# Wheelzy

1) Para la resolución de este punto se desarrolló un API RESTful utilizando NET 6 y EF.<br />
   Se utlizó el modelo Domain-Driven Design (DDD) para su arquitectura.<br />
   Para la creación de la base de datos se resolvió utilizando EF Migrations y también se utilizó EF Data Seeding para la populación de la misma.<br />
   El script solicitado se encuentra en [/databases/scripts/get_sells.sql](https://github.com/chelitotochkaru/wheelzy-technical-assessment/blob/dev/databases/scripts/get_sells.sql)<br />
   El equivalente del script en EF se consume desde el endpoint [GET] /sells (una vez iniciado el proyecto).
2) Para resolver este tipo de situaciones se me ocurre implementar alguna herramienta de cache (2nd-Level Cache / In-Memory Cache) como Redis, Memcached, Cassandra, etc.
3) * En mi experiencia el método SingleOrDefault() es menos performante que FirstOrDefault().
   * Validar que el FirstOrDefault no sea null antes de actualizar la propiedad.
   * Quitar el método dbContext.SaveChanges() de la iteración para evitar las multiples llamadas a la base de datos.
   ```csharp
   public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
   {
      foreach (var invoice in invoices)
      {
         var customer = dbContext.Customers.FirstOrDefault(invoice.CustomerId.Value);
         if (customer != null)
         {
            customer.Balance -= invoice.Total;
         }
      }
      dbContext.SaveChanges();
   }
   ```
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
