using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CREATE_DATABASE_BKP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Customer_CustomerID",
                table: "StockMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Product_ProductID",
                table: "StockMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Supplier_SupplierID",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "StockMovement",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "StockMovement",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "StockMovement",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "StockMovementID",
                table: "StockMovement",
                newName: "StockMovementId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_SupplierID",
                table: "StockMovement",
                newName: "IX_StockMovement_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_ProductID",
                table: "StockMovement",
                newName: "IX_StockMovement_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_CustomerID",
                table: "StockMovement",
                newName: "IX_StockMovement_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderDetail",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrderDetail",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderDetailID",
                table: "OrderDetail",
                newName: "OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Order",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Customer_CustomerId",
                table: "StockMovement",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Product_ProductId",
                table: "StockMovement",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Supplier_SupplierId",
                table: "StockMovement",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Customer_CustomerId",
                table: "StockMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Product_ProductId",
                table: "StockMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Supplier_SupplierId",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "StockMovement",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "StockMovement",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "StockMovement",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "StockMovementId",
                table: "StockMovement",
                newName: "StockMovementID");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_SupplierId",
                table: "StockMovement",
                newName: "IX_StockMovement_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_ProductId",
                table: "StockMovement",
                newName: "IX_StockMovement_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_CustomerId",
                table: "StockMovement",
                newName: "IX_StockMovement_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetail",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetail",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetail",
                newName: "OrderDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Order",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Customer_CustomerID",
                table: "StockMovement",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Product_ProductID",
                table: "StockMovement",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Supplier_SupplierID",
                table: "StockMovement",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
