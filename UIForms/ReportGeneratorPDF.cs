using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace iTextSharp
{
	public class ReportGeneratorPDF
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string FilePath { get; set; }

		public ReportGeneratorPDF(string filePath, DateTime startDate, DateTime endDate)
		{
			this.FilePath = filePath;
			this.StartDate = startDate;
			this.EndDate = endDate;
		}

		public void RequestProductsReport()
		{
			Document doc = new Document(PageSize.A4);
			doc.SetMargins(0, 0, 40, 40);
			doc.AddCreationDate();

			string caminho = FilePath;
			PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

			doc.Open();

			string dados = "";

			Paragraph paragrafo = new Paragraph(dados, new Font(Font.NORMAL, 14))
			{
				Alignment = Element.ALIGN_CENTER
			};
			paragrafo.Add(
				"Data inicial: " + String.Format("{0:dd/MM/yyyy}", StartDate) +
				" Data final: " + String.Format("{0:dd/MM/yyyy}", EndDate));

			PdfPTable table = new PdfPTable(3);
			PdfPCell cell = new PdfPCell();

			//Header da tabela
			table.AddCell("Produto");
			table.AddCell("Qtde Retirada do estoque");
			table.AddCell("Preço de custo total");

			//Conexão
			var connection = ConfigurationManager.ConnectionStrings["DBtriade"].ConnectionString;
			SqlConnection conn = new SqlConnection(connection);
			string sql = "SELECT Final.[Id Produto],Final.[Name Produto] , SUM(Final.[Total de Items]),SUM(Final.ItemSubtotal) FROM " +
				"(SELECT " +
				"CASE " +
					"When Type=0 Then (Product.Id) " +
					"When Type=1 Then (ProductComposition.Id) " +
				"END AS 'Id Produto', " +
				"CASE " +
					"When Type=0 Then (Product.Name) " +
					"When Type=1 Then (ProductComposition.Name) " +
				"END AS 'Name Produto', " +
				"CASE " +
					"When Type=0 Then (ProductRequest.Quantity) " +
					"When Type=1 Then (ProductComposition.Quantity * ProductRequest.Quantity) " +
				"END AS 'Total de Items'," +
				"CASE " +
					"When Type=0 Then (CostValue * ProductRequest.Quantity) " +
					"When Type=1 Then (Subtotal * ProductRequest.Quantity) " +
				"END AS 'ItemSubtotal' " +
				"FROM " +
					"(SELECT Name,ProductId,Id,SUM(Quantity) AS Quantity,(CostValue * SUM(Quantity))AS Subtotal " +
					"FROM ProductComposition " +
					"JOIN Product ON Id=ItemId " +
					"GROUP BY Name,ProductId,Id,CostValue) " +
				"AS ProductComposition " +
				"RIGHT JOIN ProductRequest ON ProductComposition.ProductId=ProductRequest.ProductId " +
				"JOIN Product ON ProductRequest.ProductId=Product.Id " +
				"JOIN Request ON ProductRequest.RequestId=Request.Id " +
				"WHERE Request.RequestDate>=@startDate AND Request.RequestDate<=@endDate) " +
				"AS Final " +
				"GROUP BY Final.[Id Produto],Final.[Name Produto];";
			conn.Open();

			SqlCommand command = new SqlCommand(sql, conn);

			command.Parameters.AddWithValue("@startDate", StartDate);
			command.Parameters.AddWithValue("@endDate", EndDate);

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					table.AddCell(reader.GetString(1));
					table.AddCell(reader.GetInt32(2).ToString());
					table.AddCell("R$" + reader.GetDecimal(3).ToString());
				}
			}
			//Footer da Tabela
			cell = new PdfPCell(new Phrase("Total"))
			{
				Colspan = 2
			};
			table.AddCell(cell);

			sql = "SELECT SUM(Final.ItemSubtotal) FROM " +
				"(SELECT " +
				"CASE " +
					"When Type=0 Then (Product.Id) " +
					"When Type=1 Then (ProductComposition.Id) " +
				"END AS 'Id Produto', " +
				"CASE " +
					"When Type=0 Then (Product.Name) " +
					"When Type=1 Then (ProductComposition.Name) " +
				"END AS 'Name Produto', " +
				"CASE " +
					"When Type=0 Then (ProductRequest.Quantity) " +
					"When Type=1 Then (ProductComposition.Quantity * ProductRequest.Quantity) " +
				"END AS 'Total de Items'," +
				"CASE " +
					"When Type=0 Then (CostValue * ProductRequest.Quantity) " +
					"When Type=1 Then (Subtotal * ProductRequest.Quantity) " +
				"END AS 'ItemSubtotal' " +
				"FROM " +
					"(SELECT Name,ProductId,Id,SUM(Quantity) AS Quantity,(CostValue * SUM(Quantity))AS Subtotal " +
					"FROM ProductComposition " +
					"JOIN Product ON Id=ItemId " +
					"GROUP BY Name,ProductId,Id,CostValue) " +
				"AS ProductComposition " +
				"RIGHT JOIN ProductRequest ON ProductComposition.ProductId=ProductRequest.ProductId " +
				"JOIN Product ON ProductRequest.ProductId=Product.Id " +
				"JOIN Request ON ProductRequest.RequestId=Request.Id " +
				"WHERE Request.RequestDate>=@startDate AND Request.RequestDate<=@endDate)" +
				"AS Final;";

			command = new SqlCommand(sql, conn);
			command.Parameters.AddWithValue("startDate", StartDate);
			command.Parameters.AddWithValue("endDate", EndDate);

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					table.AddCell("R$" + reader.GetDecimal(0).ToString());
				}
			}

			if (paragrafo.Add(table) && doc.Add(paragrafo))
			{
                //Fecha conexão e arquivo PDF
                doc.Close();
                System.Diagnostics.Process.Start(FilePath);
				MessageBox.Show(@"Relatório salvo com sucesso!", @"Sucesso ao salvar",
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
                doc.Close();
                MessageBox.Show(@"Erro ao salvar relatório", @"Erro ao salvar",
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
            conn.Close();
        }

		public void RequestReport()
		{
			using (Document doc = new Document(PageSize.A4))
			using (FileStream stream = new FileStream(FilePath, FileMode.Create))
			using (PdfWriter writer = PdfWriter.GetInstance(doc, stream))
			{
				doc.SetMargins(0, 0, 40, 40);
				doc.AddCreationDate();

				doc.Open();
                
				string dados = "";

				Paragraph paragrafo = new Paragraph(dados, new Font(Font.NORMAL, 14))
				{
					Alignment = Element.ALIGN_CENTER
				};
				paragrafo.Add(
					"Data inicial: " + String.Format("{0:dd/MM/yyyy}", StartDate) +
					" Data final: " + String.Format("{0:dd/MM/yyyy}", EndDate));

				PdfPTable table = new PdfPTable(4);
				PdfPCell cell = new PdfPCell();

				//Header da tabela
				table.AddCell("Produto");
				table.AddCell("Qtde Requisitada");
				table.AddCell("Preço de custo total");
				table.AddCell("Preço de venda total");

				//Populanto a tabela
				//instância da conexão
				var connection = ConfigurationManager.ConnectionStrings["DBtriade"].ConnectionString;
				SqlConnection conn = new SqlConnection(connection);
				string sql = "SELECT Product.Name, SUM(Quantity) AS Quantity, (Product.CostValue * SUM(Quantity)) AS CostValue, (Product.SellValue * SUM(Quantity)) AS SellValue " +
					"FROM ProductRequest " +
					"JOIN Product ON Id = ProductId " +
					"JOIN Request ON ProductRequest.RequestId = Request.Id " +
					"WHERE Request.RequestDate>=@startDate AND Request.RequestDate<=@endDate " +
					"GROUP BY ProductId,Product.Name, CostValue, SellValue " +
					"ORDER BY Product.Name;";
				conn.Open();

				SqlCommand command = new SqlCommand(sql, conn);

				command.Parameters.AddWithValue("@startDate", StartDate);
				command.Parameters.AddWithValue("@endDate", EndDate);

				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						table.AddCell(reader.GetString(0));
						table.AddCell(reader.GetInt32(1).ToString());
						table.AddCell("R$" + reader.GetDecimal(2).ToString());
						table.AddCell("R$" + reader.GetDecimal(3).ToString());
					}
				}
				//Footer da Tabela
				cell = new PdfPCell(new Phrase("Total"))
				{
					Colspan = 2
				};
				table.AddCell(cell);

				sql = "SELECT SUM(CostValue) AS CostValue, SUM(SellValue) AS SellValue FROM " +
					"(SELECT Product.Name, SUM(Quantity) AS Quantity," +
					"(Product.CostValue * SUM(Quantity)) AS CostValue," +
					"(Product.SellValue * SUM(Quantity)) AS SellValue " +
					"FROM [ProductRequest] " +
					"JOIN Product ON Id = ProductId " +
					"JOIN Request ON[ProductRequest].RequestId = Request.Id " +
				   "WHERE Request.RequestDate>=@startDate AND Request.RequestDate<=@endDate " +
					"GROUP BY ProductId, Product.Name, CostValue, SellValue, Quantity) AS Total";

				command = new SqlCommand(sql, conn);

				command.Parameters.AddWithValue("@startDate", StartDate);
				command.Parameters.AddWithValue("@endDate", EndDate);

				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						table.AddCell("R$" + reader.GetDecimal(0).ToString());
						table.AddCell("R$" + reader.GetDecimal(1).ToString());
					}
				}

				if (paragrafo.Add(table) && doc.Add(paragrafo))
				{
					//Fecha conexão e arquivo PDF
					doc.Close();
                    System.Diagnostics.Process.Start(FilePath);
                    MessageBox.Show(@"Relatório salvo com sucesso!", @"Sucesso ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					//Fecha conexão e arquivo PDF
					doc.Close();
					MessageBox.Show(@"Erro ao salvar relatório", @"Erro ao salvar",
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
                conn.Close();
            }
		}
	}
}