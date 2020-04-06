using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Bebidas','')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Lanches','')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Sobremesas','')");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,"+
                "DataCadastro,CategoriaId) Values ('Coca-Cola','Refrigerante de cola 350 ml',"+
                "'4.50','',"+
                "50,now(), (Select CategoriaId from Categorias where Nome='Bebidas'))");
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,"+
                "DataCadastro,CategoriaId) Values ('Hamburguer','Sanduiche completo artesanal',"+
                "'15.50','',40,now(), (Select CategoriaId from Categorias where Nome='Lanches'))");
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,"+
                "DataCadastro,CategoriaId) Values ('Pudim','Pudim de leite 100g',"+
                "'7.85','', 30,now(), (Select CategoriaId from Categorias where Nome='Sobremesas'))");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
