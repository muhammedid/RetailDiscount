# RetailDiscount
Calculations of the invoice given in the abc project are made and a discount is applied according to the conditions.

## Testing Steps

- RetailDBFile/Retail.bak file restore in Sql server or create sql database then run it RetailDBFile/RetailScript.sql
- Editing RetailDiscount.DataAccess\Concrete\EntityFramework\RetailContext.cs in database connection
- Run project
- Postman get method https://localhost/api/invoice/GetInvoiceCalculate?id=2 id is invoice id
